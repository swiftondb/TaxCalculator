﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.Infrastructure.Contexts;

#nullable disable

namespace TaxCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231206175219_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("TaxCalculator.Domain.Entities.TaxBand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LowerLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaxBandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("TaxRate")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UpperLimit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaxBandName")
                        .IsUnique();

                    b.ToTable("TaxBands");
                });
#pragma warning restore 612, 618
        }
    }
}
