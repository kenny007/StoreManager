using System;
using Microsoft.EntityFrameworkCore;
using StoreManager.API.Entities;

namespace StoreManager.API.Contexts
{
    public class ProductDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Store> Stores { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<ProductGroup>()
                .HasMany(p => p.SubProductGroup)
                .WithOne(p => p.ParentProductGroup)
                .HasForeignKey(p => p.ParentId);
            modelBuilder.Entity<ProductStore>().HasKey(ps => 
                new { ps.ProductId, ps.StoreId});
            modelBuilder.Entity<ProductGroup>().HasData(
                new 
                {
                    ProductGroupId = 1,
                    Name = "Group 1"
                },
                new 
                {
                    ProductGroupId = 2,
                    Name = "Group 2"
                },
                new 
                {
                    ProductGroupId = 3,
                    Name = "Group 3"
                },
                new 
                {
                    ProductGroupId = 4,
                    Name = "Group 4"
                },
                new 
                {
                    ProductGroupId = 5,
                    Name = "Group 5"
                },
                new 
                {
                    ProductGroupId = 6,
                    Name = "Group 6"
                },
                new 
                {
                    ProductGroupId = 7,
                    Name = "Group 7"
                },
                new 
                {
                    ProductGroupId = 8,
                    Name = "Group 8"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new 
                {
                    ProductId = 1,
                    ProductName = "Product 1",
                    ProductGroupId = 1,
                    DateAdded = DateTime.UtcNow
                },
                new
                {
                    ProductId = 2,
                    ProductName = "Product 2",
                    ProductGroupId = 2,
                    DateAdded = DateTime.UtcNow
                },
                new 
                {
                    ProductId = 3,
                    ProductName = "Product 3",
                    ProductGroupId = 2,
                    DateAdded = DateTime.UtcNow
                },
                new
                {
                    ProductId = 4,
                    ProductName = "Product 4",
                    ProductGroupId = 2,
                    DateAdded = DateTime.UtcNow
                },
                new 
                {
                    ProductId = 5,
                    ProductName = "Product 5",
                    ProductGroupId = 1,
                    DateAdded = DateTime.UtcNow
                },
                new
                {
                    ProductId = 6,
                    ProductName = "Product 6",
                    ProductGroupId = 3,
                    DateAdded = DateTime.UtcNow
                },
                new 
                {
                    ProductId = 7,
                    ProductName = "Product 7",
                    ProductGroupId = 3,
                    DateAdded = DateTime.UtcNow
                },
                new
                {
                    ProductId = 8,
                    ProductName = "Product 8",
                    ProductGroupId = 3,
                    DateAdded = DateTime.UtcNow
                }
            );
            modelBuilder.Entity<Store>().HasData(
                new
                {
                    Id = 1,
                    Name = "Store 1"
                },
                new 
                {
                    Id = 2,
                    Name = "Store 2"
                },
                new 
                {
                    Id = 3,
                    Name = "Store 3"
                },
                new 
                {
                    Id = 4,
                    Name = "Store 4"
                },
                new 
                {
                    Id = 5,
                    Name = "Store 5"
                }
            );
           
            modelBuilder.Entity<ProductStore>().HasData(
                new
                {
                    StoreId = 1,
                    ProductId = 1,
                    Price = 12.00m,
                    PriceWithVaT = 13.20m,
                    VatRate = 0.32m
                },
                new
                {
                    StoreId = 2,
                    ProductId = 2,
                    Price = 50.00m,
                    PriceWithVaT = 15.20m,
                    VatRate = 0.36m
                },
                new
                {
                    StoreId = 2,
                    ProductId = 1,
                    Price = 50.00m,
                    PriceWithVaT = 15.20m,
                    VatRate = 0.36m
                },
                new
                {
                    StoreId = 3,
                    ProductId = 1,
                    Price = 48.00m,
                    PriceWithVaT = 14.20m,
                    VatRate = 0.63m
                },
                new
                {
                    StoreId = 4,
                    ProductId = 1,
                    Price = 50.00m,
                    PriceWithVaT = 19.20m,
                    VatRate = 0.54m
                },
                new
                {
                    StoreId = 2,
                    ProductId = 3,
                    Price = 50.00m,
                    PriceWithVaT = 15.20m,
                    VatRate = 0.36m
                }
            );       
            
            base.OnModelCreating(modelBuilder);
        }
    }
    
}