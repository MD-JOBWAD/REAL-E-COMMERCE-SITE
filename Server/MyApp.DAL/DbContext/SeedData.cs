using Microsoft.EntityFrameworkCore;
using MyApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.DAL.DbContext
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                BrandID = 1,
                CategoryID = 1,
                Description = "test description",
                DiscountPrice = 120,
                IsActive = false,
                IsFavourite = true,
                MarketPrice = 140,
                Name = "p1",
                SalesPrice = 110,
                StockQuantity = 2,
                ID = 1,
                SKU = "ss"

            });
            modelBuilder.Entity<Color>().HasData(new Color
            {
                ID = 1, Name = "RED"
            },
            new Color
            {
                ID = 2,
                Name = "GREEN"
            });
            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                ID = 1, BandName = "test brand", CategoryID = 1, ParentBandID = 1
            },
            new Brand
            {
                ID = 2,
                BandName = "test brand Two",
                CategoryID = 1,
                ParentBandID = 1
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                ID = 1, DisplayOrder = 1, IsActive = true, Name = "test Category", ParentCategoryID = 1
            });
            modelBuilder.Entity<ProductSize>().HasData(new ProductSize
            {
                ID = 1, Chest = 1, Height = 1, IsCloth = true, Lenth = 1, Season = "sum",
                Shoulder =1, Sleeve = "test", Weight = 0, Width = 0
            });
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    ID = 1,
                    CountryName = "Bangladesh"
                },
                new Country
                {
                    ID = 2,
                    CountryName = "India"
                }
                );
            modelBuilder.Entity<District>().HasData(
                new District
                {
                    ID = 1,
                    DistrictName = "Dhaka",
                    CountryID = 1
                },
                 new District
                 {
                     ID = 2,
                     DistrictName = "Kishoreganj",
                     CountryID = 1
                 }
            );
        }
    }
}
