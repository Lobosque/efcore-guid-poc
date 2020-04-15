﻿// <auto-generated />
using System;
using GuidPoc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuicPoc.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200415154052_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("GuidPoc.Entities.Coupon", b =>
                {
                    b.Property<Guid>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("PromotionId")
                        .HasColumnType("TEXT");

                    b.HasKey("CouponId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PromotionId");

                    b.ToTable("coupon");
                });

            modelBuilder.Entity("GuidPoc.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("GuidPoc.Entities.Promotion", b =>
                {
                    b.Property<Guid>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PromotionCode")
                        .HasColumnType("TEXT");

                    b.HasKey("PromotionId");

                    b.ToTable("promotion");
                });

            modelBuilder.Entity("GuidPoc.Entities.Coupon", b =>
                {
                    b.HasOne("GuidPoc.Entities.Customer", "Customer")
                        .WithMany("Coupons")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuidPoc.Entities.Promotion", null)
                        .WithMany("Coupons")
                        .HasForeignKey("PromotionId");
                });
#pragma warning restore 612, 618
        }
    }
}
