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
    [Migration("20231206175328_TaxBandInitialData")]
    partial class TaxBandInitialData
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LowerLimit = 0,
                            TaxBandName = "Tax Band A",
                            TaxRate = 0,
                            UpperLimit = 5000
                        },
                        new
                        {
                            Id = 2,
                            LowerLimit = 5000,
                            TaxBandName = "Tax Band B",
                            TaxRate = 20,
                            UpperLimit = 20000
                        },
                        new
                        {
                            Id = 3,
                            LowerLimit = 20000,
                            TaxBandName = "Tax Band C",
                            TaxRate = 20
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
