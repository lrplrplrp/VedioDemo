using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simpie.EntityFrameworkCore;
using Video.Domain;
using Video.Domain.Users;
using Video.Domain.Videos;

namespace Video.EntityFrameworkCore
{
    public class VideoDbContext : MasterDbContext<VideoDbContext>
    {

        public DbSet<UserInfo> UserInfo {get;set;}

        public DbSet<Domain.Videos.Video> Video { get; set; }

        public DbSet<Like> Like { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Classify> Classify { get; set; }

        public DbSet<BeanVermicelli> BeanVermicelli { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
        
        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserInfo>(u=>{
                u.ToTable("UserInfo");
                u.HasComment("用户表");
                u.HasKey(x=>x.id);
                u.HasIndex(x=>x.id);
                u.Property(x=>x.UserName).HasComment("用户名");
                u.HasIndex(x=>x.UserName).IsUnique();
            });

            builder.Entity<Role>(x=>{
                x.ToTable("Roles");
                x.HasComment("角色表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.id);
            });

            builder.Entity<UserRole>(x=>{
                x.ToTable("UserRoles");
                x.HasComment("用户角色配置表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.id);
                x.HasIndex(x=>x.UserId);
                x.HasIndex(x=>x.RoleId);
            });

            builder.Entity<Domain.Videos.Video>(x=>{
                x.ToTable("Videos");
                x.HasComment("视频表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.id);
                x.HasIndex(x=>x.UserId);
                x.HasIndex(x=>x.ClassifyId);
            });

            builder.Entity<Like>(x=>{
                x.ToTable("Likes");
                x.HasComment("点赞表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.id);
                x.HasIndex(x=>x.UserId);
                x.HasIndex(x=>x.VideoId);
            });

            builder.Entity<Comment>(x=>{
                x.ToTable("Comments");
                x.HasComment("评论表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.id);
                x.HasIndex(x=>x.ParentId);
                x.HasIndex(x=>x.UserId);
                x.HasIndex(x=>x.VideoId);
            });

            builder.Entity<Classify>(x=>{
                x.ToTable("Classifys");
                x.HasComment("视频分类表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.id);
            });

            builder.Entity<BeanVermicelli>(x=>{
                x.ToTable("BeanVermicellis");
                x.HasComment("关注表");
                x.HasKey(x=>x.id);
                x.HasIndex(x=>x.UserId);
                x.HasIndex(x=>x.BeFocuseId);
            });

            #region 初始化种子数据

            var userInfo=new UserInfo{
                id=Guid.NewGuid(),
                Avatar="",
                CreateTime=DateTime.Now,
                Status=true,
                Name="admin",
                UserName="admin",
                Password="admin"
            };
            var role=new Role{
                id=Guid.NewGuid(),
                Name="admin",
                Code="admin"
            };
            var userRole=new UserRole{
                id=Guid.NewGuid(),
                RoleId=role.id,
                UserId=userInfo.id
            };

            builder.Entity<UserInfo>().HasData(userInfo);
            builder.Entity<Role>().HasData(role);
            builder.Entity<UserRole>().HasData(userRole);

            #endregion
        }
    }
}