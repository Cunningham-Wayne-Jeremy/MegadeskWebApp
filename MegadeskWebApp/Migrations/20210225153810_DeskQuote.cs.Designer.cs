﻿// <auto-generated />
using System;
using MegadeskWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegadeskWebApp.Migrations
{
    [DbContext(typeof(MegadeskWebAppContext))]
    [Migration("20210225153810_DeskQuote.cs")]
    partial class DeskQuotecs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegadeskWebApp.Models.DeskQuote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Depth");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("NumDrawers");

                    b.Property<int>("RushDays");

                    b.Property<string>("SurfaceMaterial");

                    b.Property<decimal>("Total");

                    b.Property<int>("Width");

                    b.HasKey("ID");

                    b.ToTable("DeskQuote");
                });
#pragma warning restore 612, 618
        }
    }
}
