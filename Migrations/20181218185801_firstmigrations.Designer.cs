﻿// <auto-generated />
using System;
using CbeltRetake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CbeltRetake.Migrations
{
    [DbContext(typeof(IdeaContext))]
    [Migration("20181218185801_firstmigrations")]
    partial class firstmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CbeltRetake.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("firstname")
                        .IsRequired();

                    b.Property<string>("lastname")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.HasKey("userid");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
