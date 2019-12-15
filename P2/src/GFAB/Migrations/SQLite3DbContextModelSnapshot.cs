﻿// <auto-generated />
using System;
using GFAB.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GFAB.Migrations
{
    [DbContext(typeof(SQLite3DbContext))]
    partial class SQLite3DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("GFAB.Model.Item", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("expirationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("productionDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("served")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GFAB.Model.Meal", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("GFAB.Model.Item", b =>
                {
                    b.OwnsOne("GFAB.Model.ItemID", "id", b1 =>
                        {
                            b1.Property<long>("ItemID")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ItemID");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemID");
                        });

                    b.OwnsOne("GFAB.Model.Location", "location", b1 =>
                        {
                            b1.Property<long>("ItemID")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ItemID");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemID");
                        });

                    b.OwnsOne("GFAB.Model.MealID", "mealId", b1 =>
                        {
                            b1.Property<long>("ItemID")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Id")
                                .HasColumnType("TEXT");

                            b1.HasKey("ItemID");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemID");
                        });

                    b.OwnsOne("GFAB.Model.TimePeriod", "livenessPeriod", b1 =>
                        {
                            b1.Property<long>("ItemID")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ItemID");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemID");
                        });
                });

            modelBuilder.Entity("GFAB.Model.Meal", b =>
                {
                    b.OwnsMany("GFAB.Model.Allergen", "Allergens", b1 =>
                        {
                            b1.Property<long>("MealID")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.HasKey("MealID", "Id");

                            b1.ToTable("Allergen");

                            b1.WithOwner()
                                .HasForeignKey("MealID");
                        });

                    b.OwnsMany("GFAB.Model.Descriptor", "Descriptors", b1 =>
                        {
                            b1.Property<long>("MealID")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.Property<double>("Quantity")
                                .HasColumnType("REAL");

                            b1.Property<string>("QuantityUnit")
                                .HasColumnType("TEXT");

                            b1.HasKey("MealID", "Id");

                            b1.ToTable("Descriptor");

                            b1.WithOwner()
                                .HasForeignKey("MealID");
                        });

                    b.OwnsMany("GFAB.Model.Ingredient", "Ingredients", b1 =>
                        {
                            b1.Property<long>("MealID")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.HasKey("MealID", "Id");

                            b1.ToTable("Ingredient");

                            b1.WithOwner()
                                .HasForeignKey("MealID");
                        });

                    b.OwnsOne("GFAB.Model.MealID", "Designation", b1 =>
                        {
                            b1.Property<long>("MealID")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Id")
                                .HasColumnType("TEXT");

                            b1.HasKey("MealID");

                            b1.ToTable("Meals");

                            b1.WithOwner()
                                .HasForeignKey("MealID");
                        });

                    b.OwnsOne("GFAB.Model.MealType", "Type", b1 =>
                        {
                            b1.Property<long>("MealID")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.HasKey("MealID");

                            b1.ToTable("Meals");

                            b1.WithOwner()
                                .HasForeignKey("MealID");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
