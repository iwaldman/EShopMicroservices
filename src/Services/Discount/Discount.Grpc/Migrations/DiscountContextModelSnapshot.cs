﻿// <auto-generated />
using Discount.Grpc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discount.Grpc.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Discount.Grpc.Models.Coupon", b =>
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
                            Description = "IPhone Discount",
                            ProductName = "IPhone X"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 100,
                            Description = "Samsung Discount",
                            ProductName = "Samsung 10"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 50,
                            Description = "Huawei Discount",
                            ProductName = "Huawei P30"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 20,
                            Description = "Xiaomi Discount",
                            ProductName = "Xiaomi Mi 10"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 30,
                            Description = "LG Discount",
                            ProductName = "LG G8"
                        },
                        new
                        {
                            Id = 6,
                            Amount = 80,
                            Description = "Sony Discount",
                            ProductName = "Sony Xperia 1"
                        },
                        new
                        {
                            Id = 7,
                            Amount = 75,
                            Description = "One Plus Discount",
                            ProductName = "One Plus 7T"
                        },
                        new
                        {
                            Id = 8,
                            Amount = 60,
                            Description = "Google Discount",
                            ProductName = "Google Pixel 4"
                        },
                        new
                        {
                            Id = 9,
                            Amount = 200,
                            Description = "Oppo Discount",
                            ProductName = "Oppo Reno"
                        },
                        new
                        {
                            Id = 10,
                            Amount = 95,
                            Description = "Vivo Discount",
                            ProductName = "Vivo Nex 3"
                        },
                        new
                        {
                            Id = 11,
                            Amount = 150,
                            Description = "Honor Discount",
                            ProductName = "Honor 20"
                        },
                        new
                        {
                            Id = 12,
                            Amount = 100,
                            Description = "Nokia Discount",
                            ProductName = "Nokia 9"
                        },
                        new
                        {
                            Id = 13,
                            Amount = 50,
                            Description = "Blackberry Discount",
                            ProductName = "Blackberry Key 2"
                        },
                        new
                        {
                            Id = 14,
                            Amount = 20,
                            Description = "HTC Discount",
                            ProductName = "HTC U12+"
                        },
                        new
                        {
                            Id = 15,
                            Amount = 30,
                            Description = "Asus Discount",
                            ProductName = "Asus Zenfone 6"
                        },
                        new
                        {
                            Id = 16,
                            Amount = 80,
                            Description = "ZTE Discount",
                            ProductName = "ZTE Nubia Red Magic"
                        },
                        new
                        {
                            Id = 17,
                            Amount = 75,
                            Description = "Sharp Discount",
                            ProductName = "Sharp Aquos R2"
                        },
                        new
                        {
                            Id = 18,
                            Amount = 60,
                            Description = "Lenovo Discount",
                            ProductName = "Lenovo Z6 Pro"
                        },
                        new
                        {
                            Id = 19,
                            Amount = 200,
                            Description = "Panasonic Discount",
                            ProductName = "Panasonic Eluga X1 Pro"
                        },
                        new
                        {
                            Id = 20,
                            Amount = 95,
                            Description = "Cat Discount",
                            ProductName = "Cat S61"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
