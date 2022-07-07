﻿// <auto-generated />
using System;
using Food_Delivery_Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Food_Delivery_Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220707150605_TheRightMigration")]
    partial class TheRightMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Food_Delivery_Core.Models.Dish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DelivererId")
                        .HasColumnType("bigint");

                    b.Property<long>("DeliveryId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrdererId")
                        .HasColumnType("bigint");

                    b.Property<long>("RestorauntId")
                        .HasColumnType("bigint");

                    b.Property<long>("RestourantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeOfOrder")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DelivererId");

                    b.HasIndex("OrdererId");

                    b.HasIndex("RestorauntId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("DishId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.Restaurant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("RestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Restoraunts");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.Dish", b =>
                {
                    b.HasOne("Food_Delivery_Core.Models.Restaurant", "restoraunt")
                        .WithMany("Menu")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("restoraunt");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.Order", b =>
                {
                    b.HasOne("Food_Delivery_Core.Models.User", "Deliverer")
                        .WithMany()
                        .HasForeignKey("DelivererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Food_Delivery_Core.Models.User", "Orderer")
                        .WithMany()
                        .HasForeignKey("OrdererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Food_Delivery_Core.Models.Restaurant", "Restoraunt")
                        .WithMany()
                        .HasForeignKey("RestorauntId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deliverer");

                    b.Navigation("Orderer");

                    b.Navigation("Restoraunt");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.OrderItem", b =>
                {
                    b.HasOne("Food_Delivery_Core.Models.Dish", "FoodItem")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Food_Delivery_Core.Models.Order", "Order")
                        .WithMany("Dishes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.Order", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("Food_Delivery_Core.Models.Restaurant", b =>
                {
                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}