﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Prioritify.Data.DbContexts;

#nullable disable

namespace Prioritify.Data.Migrations.PrioritifyDb
{
    [DbContext(typeof(PrioritifyDbContext))]
    [Migration("20230326151929_AddTbTasks")]
    partial class AddTbTasks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Prioritify.Data.Tables.TbTasks", b =>
                {
                    b.Property<string>("flId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FinishedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("flDeadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("flDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("flName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("flPrevVersionsInJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("flStatus")
                        .HasColumnType("integer");

                    b.Property<int>("flUserId")
                        .HasColumnType("integer");

                    b.HasKey("flId");

                    b.ToTable("tbtasks", "application");
                });
#pragma warning restore 612, 618
        }
    }
}
