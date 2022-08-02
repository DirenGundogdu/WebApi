using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(28,3)");

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new(){Id=1, Name="Pc", CreateDate= DateTime.Now.AddDays(-3),Price=15000,Stock=399},
                new(){Id=2, Name="Phone", CreateDate= DateTime.Now.AddDays(-30),Price=10000,Stock=2500},
                new(){Id=3, Name="Keyboard", CreateDate= DateTime.Now.AddDays(-60),Price=500,Stock=5000},
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

    }
}
