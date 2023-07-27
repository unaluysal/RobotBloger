﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RobotBloger.Infrastrucute.Data;

#nullable disable

namespace RobotBloger.Infrastrucute.Data.Migrations
{
    [DbContext(typeof(RobotBlogerDbContext))]
    [Migration("20230418212300_t2")]
    partial class t2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("RobotBloger")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RobotBloger.Domain.Entitys.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("AltTag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BigPhoto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BlogTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RelaseTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("SmallPhoto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BlogTypeId");

                    b.ToTable("Blogs", "RobotBloger");
                });

            modelBuilder.Entity("RobotBloger.Domain.Entitys.BlogType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("BlogTypes", "RobotBloger");
                });

            modelBuilder.Entity("RobotBloger.Domain.Entitys.StaticWord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlogTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BlogTypeId");

                    b.ToTable("StaticWords", "RobotBloger");
                });

            modelBuilder.Entity("RobotBloger.Domain.Entitys.Blog", b =>
                {
                    b.HasOne("RobotBloger.Domain.Entitys.BlogType", "BlogType")
                        .WithMany()
                        .HasForeignKey("BlogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogType");
                });

            modelBuilder.Entity("RobotBloger.Domain.Entitys.StaticWord", b =>
                {
                    b.HasOne("RobotBloger.Domain.Entitys.BlogType", "BlogType")
                        .WithMany()
                        .HasForeignKey("BlogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogType");
                });
#pragma warning restore 612, 618
        }
    }
}
