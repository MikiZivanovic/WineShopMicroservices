﻿// <auto-generated />
using DiscountGRPC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiscountGRPC.Migrations
{
    [DbContext(typeof(DiscountContext))]
    [Migration("20250401123618_IzmenaInitialData")]
    partial class IzmenaInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("DiscountGRPC.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 150,
                            Description = "Tamjanika Discount",
                            ProductName = "Tamjanika Delight"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 100,
                            Description = "Pinot Noir Eleganc Discount",
                            ProductName = "Pinot Noir Elegance"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
