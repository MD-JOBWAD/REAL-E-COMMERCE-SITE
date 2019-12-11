using Microsoft.EntityFrameworkCore;
using MyApp.DAL.DbContext;
using MyApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.DAL
{
    public class DataDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> Options) : base(Options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingProgress> ShippingProgresses { get; set; }
        public DbSet<TransectionHistory> TransectionHistories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
    }//c

}//ns
