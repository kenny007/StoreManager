﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManager.API.Contexts;

namespace StoreManager.API.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20181204210646_InitialDbCreation")]
    partial class InitialDbCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreManager.API.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("ProductGroupId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("ProductId");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Products");

                    b.HasData(
                        new { ProductId = 1, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 1, ProductName = "Product 1" },
                        new { ProductId = 2, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 2, ProductName = "Product 2" },
                        new { ProductId = 3, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 2, ProductName = "Product 3" },
                        new { ProductId = 4, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 2, ProductName = "Product 4" },
                        new { ProductId = 5, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 1, ProductName = "Product 5" },
                        new { ProductId = 6, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 3, ProductName = "Product 6" },
                        new { ProductId = 7, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 3, ProductName = "Product 7" },
                        new { ProductId = 8, DateAdded = new DateTime(2018, 12, 4, 21, 6, 46, 127, DateTimeKind.Utc), ProductGroupId = 3, ProductName = "Product 8" }
                    );
                });

            modelBuilder.Entity("StoreManager.API.Entities.ProductGroup", b =>
                {
                    b.Property<int>("ProductGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentId");

                    b.HasKey("ProductGroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductGroups");

                    b.HasData(
                        new { ProductGroupId = 1, Name = "Group 1" },
                        new { ProductGroupId = 2, Name = "Group 2" },
                        new { ProductGroupId = 3, Name = "Group 3" },
                        new { ProductGroupId = 4, Name = "Group 4" },
                        new { ProductGroupId = 5, Name = "Group 5" },
                        new { ProductGroupId = 6, Name = "Group 6" },
                        new { ProductGroupId = 7, Name = "Group 7" },
                        new { ProductGroupId = 8, Name = "Group 8" }
                    );
                });

            modelBuilder.Entity("StoreManager.API.Entities.ProductStore", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("StoreId");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceWithVaT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("VatRate")
                        .HasColumnType("decimal(6,4)");

                    b.HasKey("ProductId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductStores");

                    b.HasData(
                        new { ProductId = 1, StoreId = 1, Price = 12.00m, PriceWithVaT = 13.20m, VatRate = 0.32m },
                        new { ProductId = 2, StoreId = 2, Price = 50.00m, PriceWithVaT = 15.20m, VatRate = 0.36m },
                        new { ProductId = 1, StoreId = 2, Price = 50.00m, PriceWithVaT = 15.20m, VatRate = 0.36m },
                        new { ProductId = 1, StoreId = 3, Price = 48.00m, PriceWithVaT = 14.20m, VatRate = 0.63m },
                        new { ProductId = 1, StoreId = 4, Price = 50.00m, PriceWithVaT = 19.20m, VatRate = 0.54m },
                        new { ProductId = 3, StoreId = 2, Price = 50.00m, PriceWithVaT = 15.20m, VatRate = 0.36m }
                    );
                });

            modelBuilder.Entity("StoreManager.API.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stores");

                    b.HasData(
                        new { Id = 1, Name = "Store 1" },
                        new { Id = 2, Name = "Store 2" },
                        new { Id = 3, Name = "Store 3" },
                        new { Id = 4, Name = "Store 4" },
                        new { Id = 5, Name = "Store 5" }
                    );
                });

            modelBuilder.Entity("StoreManager.API.Entities.Product", b =>
                {
                    b.HasOne("StoreManager.API.Entities.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StoreManager.API.Entities.ProductGroup", b =>
                {
                    b.HasOne("StoreManager.API.Entities.ProductGroup", "ParentProductGroup")
                        .WithMany("SubProductGroup")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("StoreManager.API.Entities.ProductStore", b =>
                {
                    b.HasOne("StoreManager.API.Entities.Product", "Product")
                        .WithMany("ProductStores")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StoreManager.API.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
