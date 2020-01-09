﻿// <auto-generated />
using System;
using CostRegisterMobile.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CostRegisterMobile.Migrations
{
    [DbContext(typeof(CostPlansContext))]
    [Migration("20191210190045_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("CostRegisterMobile.EntityModels.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Rezsi"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Lakbér"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Háztartás és élelmiszer"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Ruházat"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Sport"
                        },
                        new
                        {
                            CategoryID = 6,
                            CategoryName = "Hobbik"
                        },
                        new
                        {
                            CategoryID = 7,
                            CategoryName = "Egészségügyi"
                        },
                        new
                        {
                            CategoryID = 8,
                            CategoryName = "Háztartási gépek és karbantartás"
                        },
                        new
                        {
                            CategoryID = 9,
                            CategoryName = "Extra"
                        },
                        new
                        {
                            CategoryID = 10,
                            CategoryName = "Egyéb"
                        });
                });

            modelBuilder.Entity("CostRegisterMobile.EntityModels.Costs", b =>
                {
                    b.Property<int>("CostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("AmountOfCost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCost")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShopID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CostID");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("CostRegisterMobile.EntityModels.Income", b =>
                {
                    b.Property<int>("IncomeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountOfIncome")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOFIncome")
                        .HasColumnType("TEXT");

                    b.Property<string>("IncomeAdditionalInformation")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("TypeOfIncome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("IncomeID");

                    b.ToTable("Income");
                });

            modelBuilder.Entity("CostRegisterMobile.EntityModels.PlanCost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CostPlanned")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfPlan")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlanAdditionalInformation")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("TypeOfCostPlan")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("PlanCosts");
                });

            modelBuilder.Entity("CostRegisterMobile.EntityModels.Settings", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SettingMode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SettingType")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            SettingMode = 1,
                            SettingType = "IncludePlans"
                        });
                });

            modelBuilder.Entity("CostRegisterMobile.EntityModels.Shops", b =>
                {
                    b.Property<int>("ShopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ShopID");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            ShopID = 1,
                            ShopName = "Lidl"
                        },
                        new
                        {
                            ShopID = 2,
                            ShopName = "Aldi"
                        },
                        new
                        {
                            ShopID = 3,
                            ShopName = "Penny Market"
                        },
                        new
                        {
                            ShopID = 4,
                            ShopName = "Reál"
                        },
                        new
                        {
                            ShopID = 5,
                            ShopName = "Tesco"
                        },
                        new
                        {
                            ShopID = 6,
                            ShopName = "Auchan"
                        },
                        new
                        {
                            ShopID = 7,
                            ShopName = "CBA"
                        },
                        new
                        {
                            ShopID = 8,
                            ShopName = "COOP"
                        },
                        new
                        {
                            ShopID = 9,
                            ShopName = "Decathlon"
                        },
                        new
                        {
                            ShopID = 10,
                            ShopName = "Obi"
                        },
                        new
                        {
                            ShopID = 11,
                            ShopName = "IKEA"
                        },
                        new
                        {
                            ShopID = 12,
                            ShopName = "KIKA"
                        },
                        new
                        {
                            ShopID = 13,
                            ShopName = "Praktiker"
                        },
                        new
                        {
                            ShopID = 14,
                            ShopName = "DM"
                        },
                        new
                        {
                            ShopID = 15,
                            ShopName = "Rossmann"
                        },
                        new
                        {
                            ShopID = 16,
                            ShopName = "Fressnapf"
                        },
                        new
                        {
                            ShopID = 17,
                            ShopName = "Bershka"
                        },
                        new
                        {
                            ShopID = 18,
                            ShopName = "New Yorker"
                        },
                        new
                        {
                            ShopID = 19,
                            ShopName = "C&A"
                        },
                        new
                        {
                            ShopID = 20,
                            ShopName = "Egyéb/nem üzlet"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
