using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Simpie.EntityFrameworkCore
{
    public class MasterDbContext<IDbContext> : DbContext where IDbContext : DbContext
    {
        protected MasterDbContext(DbContextOptions<IDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //禁用跟踪查询
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            #if DEBUG
            //显示详细日志
            optionsBuilder.EnableDetailedErrors();            
            #endif
        }
    }
}