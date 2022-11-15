using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simpie.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Core;

namespace Simpie.EntityFrameworkCore
{
    
    public static class SimplyEntityFrameworkExtension
    {
        /// <summary>
        /// efcore核心扩展
        /// </summary>
        /// <param name="service"></param>
        /// <param name="options"></param>
        /// <param name="lifetime"></param>
        /// <typeparam name="IDbContext"></typeparam>
        /// <returns></returns>
        public static IServiceCollection AddEntityFrameworkCore<IDbContext>(
            this IServiceCollection service,
            Action<DbContextOptionsBuilder>? options=null,
            ServiceLifetime lifetime=ServiceLifetime.Singleton)
            where IDbContext:MasterDbContext<IDbContext>
            {
            service.AddDbContext<IDbContext>(options);
            service.AddTransient<IUnitOfWork,UnitOfWork<IDbContext>>();
            return service;
        }
    }
}