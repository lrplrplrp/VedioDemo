﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Video.EntityFrameworkCore;

#nullable disable

namespace Video.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    [Migration("20221104005403_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Video.Domain.Role", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("id");

                    b.ToTable("Roles", (string)null);

                    b.HasComment("角色表");
                });

            modelBuilder.Entity("Video.Domain.UserRole", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.HasIndex("id");

                    b.ToTable("UserRoles", (string)null);

                    b.HasComment("用户角色配置表");
                });

            modelBuilder.Entity("Video.Domain.Users.UserInfo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(95)")
                        .HasComment("用户名");

                    b.HasKey("id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("id");

                    b.ToTable("UserInfo", (string)null);

                    b.HasComment("用户表");
                });

            modelBuilder.Entity("Video.Domain.Videos.BeanVermicelli", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BeFocuseId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("BeFocuseId");

                    b.HasIndex("UserId");

                    b.ToTable("BeanVermicellis", (string)null);

                    b.HasComment("关注表");
                });

            modelBuilder.Entity("Video.Domain.Videos.Classify", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("id");

                    b.ToTable("Classifys", (string)null);

                    b.HasComment("视频分类表");
                });

            modelBuilder.Entity("Video.Domain.Videos.Comment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.HasIndex("id");

                    b.ToTable("Comments", (string)null);

                    b.HasComment("评论表");
                });

            modelBuilder.Entity("Video.Domain.Videos.Like", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.HasIndex("id");

                    b.ToTable("Likes", (string)null);

                    b.HasComment("点赞表");
                });

            modelBuilder.Entity("Video.Domain.Videos.Video", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClassifyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("ClassifyId");

                    b.HasIndex("UserId");

                    b.HasIndex("id");

                    b.ToTable("Videos", (string)null);

                    b.HasComment("视频表");
                });

            modelBuilder.Entity("Video.Domain.Videos.Comment", b =>
                {
                    b.HasOne("Video.Domain.Users.UserInfo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Video.Domain.Videos.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Video.Domain.Videos.Like", b =>
                {
                    b.HasOne("Video.Domain.Users.UserInfo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Video.Domain.Videos.Video", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("Video.Domain.Videos.Video", b =>
                {
                    b.HasOne("Video.Domain.Videos.Classify", "Classify")
                        .WithMany()
                        .HasForeignKey("ClassifyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Video.Domain.Users.UserInfo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classify");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
