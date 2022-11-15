using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simpie.EntityFrameworkCore;

namespace Simple.EntityFrameworkCore.MySql
{
    public static class SimpleEntityFrameworkCoreMysql
    {
        public static IServiceCollection AddMySqlEntityFrameWorkCore<IDbContext>(this IServiceCollection services,string connect)
        where IDbContext:MasterDbContext<IDbContext>{
            var configuration=services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddEntityFrameworkCore<IDbContext>(x=>{x.UseMySql(configuration.GetConnectionString(connect),new MySqlServerVersion(new Version(5,5,28)));},ServiceLifetime.Singleton);
            return services;
        }
        
    }
}