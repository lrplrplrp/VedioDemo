using System.Text;
using FreeRedis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Video.Application;
using Video.EntityFrameworkCore;
using Video.HttpApi.Host.Filters;
using Video.HttpApi.Host.Options;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",//根据环境变量加载指定配置
        optional: true).Build())
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/log/", "log"),
            rollingInterval: RollingInterval.Day))//写入日志到文件
    .WriteTo.Async(c => c.Console())
    .CreateLogger();



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddVideoEntityFrameworkCore();

Log.Logger.Information("测试日志提供程序");

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwaggerGen(option => option.CustomSchemaIds(x => x.FullName));

builder.Services.AddSwaggerGen(delegate (SwaggerGenOptions option)
{
    option.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "v1.0",//版本
        Title = "Video Api 文档",//标题
        Description = "Video Api 文档",//描述
        Contact = new OpenApiContact
        {
            Name = "lrp",//作者
            Email = "2833784318@qq.com",//邮箱
            Url = new Uri("https://github.com/lrplrplrp")//可以放Github地址
        }
    });
    //加载xml文档，显示Swaffer的注释
    string[] files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");//获取api文档
    string[] array = files;
    foreach (string filePath in array)
    {
        option.IncludeXmlComments(filePath, includeControllerXmlComments: true);
    }

    //添加安全要求
    option.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
        new OpenApiSecurityScheme{
            Reference=new OpenApiReference{
                Id="Bearer",
                Type=ReferenceType.SecurityScheme
            }
        },
        Array.Empty<string>()
        }
    });

    //添加Authorization的输入框
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "请输入token,格式为 Bearer xxxxxxxx（注意中间必须有空格）",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
});

#region JWT组件注入
var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
var jwtsection = configuration.GetSection(nameof(JWTOptions));//读取配置
builder.Services.Configure<JWTOptions>(jwtsection);//将配置绑定到类
var jwt = jwtsection.Get<JWTOptions>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,//是否在令牌期间验证签发者
            ValidateAudience = true,//是否验证接收者
            ValidateLifetime = true,//是否验证失效时间
            ValidateIssuerSigningKey = true,//是否验证签名
            ValidAudience = jwt.Audience,//接收者
            ValidIssuer = jwt.Issuer,//签发者，签发token的人
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey))
        };
    }
    );
#endregion

#region Dto
builder.Services.AddVideoApplication();
#endregion

builder.Services.AddMvcCore(options=>{
    options.Filters.Add<ResponseFilter>();
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddSingleton(new RedisClient(configuration["RedisConnection"]));

builder.Services.AddTransient<IHttpContextAccessor,HttpContextAccessor>();


var app = builder.Build();

//判断开发环境,非开发环境禁用swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Video Web Api");
        c.DocExpansion(DocExpansion.None);
        c.DefaultModelExpandDepth(-1);
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();//认证
app.UseAuthorization();//授权

app.MapControllers();

app.Run();
