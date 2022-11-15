using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Video.Application.Code;
using Video.Application.Contract.Code;
using Video.Application.Contract.UserInfos;
using Video.Application.Manage;
using Video.Application.UserInfos;

namespace Video.Application
{
    public static class VideoApplicationExtension
    {
        public static void AddVideoApplication(this IServiceCollection services){
            services.AddAutoMapper(typeof(VideoApplicationExtension).Assembly);
            services.AddTransient<IUserInfoService,UserInfoService>();
            services.AddTransient<CurrentManage>();
            services.AddTransient<ICodeService,CodeService>();
        }
    }
}