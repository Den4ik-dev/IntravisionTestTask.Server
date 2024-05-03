﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240428173013_RemoveDrinkEntityAndCreateDrinkComplexProperty")]
    partial class RemoveDrinkEntityAndCreateDrinkComplexProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.DrinkLine.DrinkLine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("drink_line_id");

                    b.Property<int>("DrinksQuantityInMachine")
                        .HasColumnType("int")
                        .HasColumnName("drinks_quantity_in_machine");

                    b.HasKey("Id");

                    b.ToTable("drink_lines", (string)null);
                });

            modelBuilder.Entity("Domain.MachineWithDrinks.MachineWithDrinks", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("machine_with_drink_id");

                    b.Property<int>("CoinsQuantity")
                        .HasColumnType("int")
                        .HasColumnName("coins_quantity");

                    b.HasKey("Id");

                    b.ToTable("machines_with_drinks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoinsQuantity = 0
                        });
                });

            modelBuilder.Entity("Domain.Nominal.Nominal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("nominal_id");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit")
                        .HasColumnName("is_blocked");

                    b.Property<int>("Value")
                        .HasColumnType("int")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("nominals", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsBlocked = false,
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            IsBlocked = false,
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            IsBlocked = false,
                            Value = 5
                        },
                        new
                        {
                            Id = 4,
                            IsBlocked = false,
                            Value = 10
                        });
                });

            modelBuilder.Entity("Domain.DrinkLine.DrinkLine", b =>
                {
                    b.OwnsOne("Domain.DrinkLine.ValueObject.Drink", "Drink", b1 =>
                        {
                            b1.Property<Guid>("DrinkLineId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Image")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("image_path");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("name");

                            b1.Property<int>("Price")
                                .HasColumnType("int")
                                .HasColumnName("price");

                            b1.HasKey("DrinkLineId");

                            b1.HasIndex("Image")
                                .IsUnique();

                            b1.HasIndex("Name")
                                .IsUnique();

                            b1.ToTable("drink_lines");

                            b1.WithOwner()
                                .HasForeignKey("DrinkLineId");
                        });

                    b.Navigation("Drink")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
