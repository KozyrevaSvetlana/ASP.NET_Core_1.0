using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db.TestProject
{
    public class DatabaseContextTests : DbContext
    {
        public DbSet<Product> AllProducts { get; set; }
        public DatabaseContextTests(DbContextOptions<DbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(p => p.Product)
                .WithMany(t => t.Images)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CartItem>()
                .HasOne(p => p.Product)
                .WithMany(t => t.CartItems)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
                .HasOne(b => b.UserContacts)
                .WithOne(i => i.Order)
                .HasForeignKey<UserContact>(b => b.OrderId);
            var image01 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/1.jpg",
                ProductId = Guid.Parse("a3f432a9-17a0-4307-984b-290611a248f5")
            };
            var image02 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/2.jpg",
                ProductId = Guid.Parse("c9f07f92-c9d5-4e8f-8093-5c242997ba82")
            };
            var image03 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/3.jpg",
                ProductId = Guid.Parse("fe7524c9-a431-4b5b-83b2-9568c7f37bfa")
            };        
            modelBuilder.Entity<Image>().HasData(image01, image02, image03);
            var product01 = new Product()
            {
                Id = Guid.Parse("a3f432a9-17a0-4307-984b-290611a248f5"),
                Cost = 11426,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Name = "Пистолетик",
            };
            var product02 = new Product()
            {
                Id = Guid.Parse("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                Cost = 11426,
                Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim",
                Name = "Шапка",
            };
            var product03 = new Product()
            {
                Id = Guid.Parse("fe7524c9-a431-4b5b-83b2-9568c7f37bfa "),
                Cost = 10398,
                Description = "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ",
                Name = "Конструктор",
            };
            modelBuilder.Entity<Product>()
            .HasData(product01, product02, product03);
        }
    }
}
