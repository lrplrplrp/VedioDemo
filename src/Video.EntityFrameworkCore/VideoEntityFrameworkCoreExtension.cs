using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simpie.EntityFrameworkCore;
using Simpie.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.MySql;
using Video.Domain.Users;
using Video.EntityFrameworkCore.User;

namespace Video.EntityFrameworkCore
{
    public static class VideoEntityFrameworkCoreExtension
    {
        public static IServiceCollection AddVideoEntityFrameworkCore(this IServiceCollection services){
            services.AddMySqlEntityFrameWorkCore<VideoDbContext>("Default");
            services.AddTransient<IUserInfoRepository,UserInfoRepository>();
            
            return services;
        }
    }
}