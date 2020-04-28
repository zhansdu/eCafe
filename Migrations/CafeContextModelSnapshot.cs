﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using newProjectJs.Data;

namespace newProjectJs.Migrations
{
    [DbContext(typeof(CafeContext))]
    partial class CafeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("newProjectJs.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("newProjectJs.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Money");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("newProjectJs.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<int>("RestaurantId");

                    b.Property<string>("Type");

                    b.HasKey("FoodId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("newProjectJs.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.HasKey("ManagerId");

                    b.HasIndex("AdminId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("newProjectJs.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("RestaurantId");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TableId");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("newProjectJs.Models.OrderFood", b =>
                {
                    b.Property<int>("OrderFoodId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoodId");

                    b.Property<int>("OrderId");

                    b.HasKey("OrderFoodId");

                    b.ToTable("OrderFood");
                });

            modelBuilder.Entity("newProjectJs.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("ManagerId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("RestaurantId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("newProjectJs.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<int>("RestaurantId");

                    b.Property<int>("SeatsCount");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("newProjectJs.Models.Food", b =>
                {
                    b.HasOne("newProjectJs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("newProjectJs.Models.Manager", b =>
                {
                    b.HasOne("newProjectJs.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("newProjectJs.Models.Order", b =>
                {
                    b.HasOne("newProjectJs.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("newProjectJs.Models.Restaurant", "restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("newProjectJs.Models.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("newProjectJs.Models.Restaurant", b =>
                {
                    b.HasOne("newProjectJs.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("newProjectJs.Models.Table", b =>
                {
                    b.HasOne("newProjectJs.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
