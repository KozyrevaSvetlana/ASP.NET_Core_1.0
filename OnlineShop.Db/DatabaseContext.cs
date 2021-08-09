using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(p => p.Product)
                .WithMany(t => t.Images)
                .HasForeignKey(p=>p.ProductId)
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
            var image04 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/3.jpg",
                ProductId = Guid.Parse("fce4ebfe-1ae7-4e47-b29f-1d34916fc298")
            };
            var image05 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/5.jpg",
                ProductId = Guid.Parse("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7")
            };
            var image06 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/6.jpg",
                ProductId = Guid.Parse("56db2983-947f-45d5-ba51-5d5cef5cf7a5")
            };

            var image07 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/6.jpg",
                ProductId = Guid.Parse("8002540c-9944-4b42-ac8c-01ad787e81e6")
            };

            var image08 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/5.jpg",
                ProductId = Guid.Parse("7a2227e4-4603-444f-ae2d-099079474ea0")
            };
            var image09 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/4.jpg",
                ProductId = Guid.Parse("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57")
            };
            var image10 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/3.jpg",
                ProductId = Guid.Parse("e54fae4f-7d6c-4e34-aa1b-820cdc772653")
            };
            var image11 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/2.jpg",
                ProductId = Guid.Parse("615496eb-0537-4657-8237-f033266a3a57")
            };
            var image12 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/1.jpg",
                ProductId = Guid.Parse("0cb8d9f0-c806-462c-a1b6-3f095b324761")
            };
            var image13 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/2.jpg",
                ProductId = Guid.Parse("27baabe2-d81b-4c46-86e0-23b97d7637c8")
            };
            var image14 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/3.jpg",
                ProductId = Guid.Parse("fbb6b537-d539-47ee-95c6-386b5ac0679a")
            };
            var image15 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/4.jpg",
                ProductId = Guid.Parse("a1ffa88c-1316-42a8-8601-95d70a65d150")
            };
            var image16 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/5.jpg",
                ProductId = Guid.Parse("0794a187-dfea-4807-9259-a7ff279455f2")
            };
            var image17 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/6.jpg",
                ProductId = Guid.Parse("bb71353d-1a58-45a2-84da-9b4137bec6f6")
            };
            var image18 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/4.jpg",
                ProductId = Guid.Parse("755221a6-0f45-4e86-9948-6e9f85872734")
            };
            var image19 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/3.jpg",
                ProductId = Guid.Parse("133788f9-139f-453e-b543-98b5876c4cb7")
            };
            var image20 = new Image
            {
                Id = Guid.NewGuid(),
                Url = "/img/Products/1.jpg",
                ProductId = Guid.Parse("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f")
            };
            modelBuilder.Entity<Image>().HasData(image01, image02, image03, image04, image05, image06, image07, image08, image09, image10, image11, image12, image13,
                image14, image15, image16, image17, image18, image19, image20);



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
            var product04 = new Product()
            {
                Id = Guid.Parse("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"),
                Cost = 94608,
                Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate",
                Name = "Пистолетик",
            };
            var product05 = new Product()
            {
                Id = Guid.Parse("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"),
                Cost = 83000,
                Description = "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat",
                Name = "Мишка",
            };
            var product06 = new Product()
            {
                Id = Guid.Parse("56db2983-947f-45d5-ba51-5d5cef5cf7a5"),
                Cost = 38020,
                Description = "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                Name = "Пирамидка",
            };
            var product07 = new Product()
            {
                Id = Guid.Parse("8002540c-9944-4b42-ac8c-01ad787e81e6"),
                Cost = 59657,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing",
                Name = "Трусы",
            };
            var product08 = new Product()
            {
                Id = Guid.Parse("7a2227e4-4603-444f-ae2d-099079474ea0"),
                Cost = 73815,
                Description = "Ex ea commodo consequat.Duis aute irure dolor",
                Name = "Пистолетик",
            };
            var product09 = new Product()
            {
                Id = Guid.Parse("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"),
                Cost = 66068,
                Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna ",
                Name = "Пистолетик",
            };
            var product10 = new Product()
            {
                Id = Guid.Parse("e54fae4f-7d6c-4e34-aa1b-820cdc772653"),
                Cost = 51625,
                Description = "Velit esse cillum dolore eu fugiat nulla pariatur.E",
                Name = "Ложка",
            };
            var product11 = new Product()
            {
                Id = Guid.Parse("615496eb-0537-4657-8237-f033266a3a57"),
                Cost = 76311,
                Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                Name = "Пистолетик",
            };
            var product12 = new Product()
            {
                Id = Guid.Parse("0cb8d9f0-c806-462c-a1b6-3f095b324761"),
                Cost = 12248,
                Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v",
                Name = "Соска",
            };
            var product13 = new Product()
            {
                Id = Guid.Parse("27baabe2-d81b-4c46-86e0-23b97d7637c8"),
                Cost = 4225,
                Description = "Ex ea commodo consequat.Duis aute i ",
                Name = "Ложка",
            };
            var product14 = new Product()
            {
                Id = Guid.Parse("fbb6b537-d539-47ee-95c6-386b5ac0679a "),
                Cost = 54643,
                Description = "Minim veniam, quis nostrud exercitation ullamco laboris ",
                Name = "Конструктор",
            };
            var product15 = new Product()
            {
                Id = Guid.Parse("a1ffa88c-1316-42a8-8601-95d70a65d150"),
                Cost = 18346,
                Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                Name = "Шапка",
            };
            var product16 = new Product()
            {
                Id = Guid.Parse("0794a187-dfea-4807-9259-a7ff279455f2"),
                Cost = 94741,
                Description = "Ex ea commodo consequat.Duis aute irure dolor in r",
                Name = "Кукла",
            };
            var product17 = new Product()
            {
                Id = Guid.Parse("bb71353d-1a58-45a2-84da-9b4137bec6f6"),
                Cost = 6957,
                Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                Name = "Кукла",
            };
            var product18 = new Product()
            {
                Id = Guid.Parse("755221a6-0f45-4e86-9948-6e9f85872734"),
                Cost = 82167,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Name = "Ложка",
            };
            var product19 = new Product()
            {
                Id = Guid.Parse("133788f9-139f-453e-b543-98b5876c4cb7"),
                Cost = 82167,
                Description = "Velit esse cillum dolore eu fugiat nulla pariatur",
                Name = "Чашка",
            };
            var product20 = new Product()
            {
                Id = Guid.Parse("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"),
                Cost = 88268,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Name = "Ползунки",
            };
                modelBuilder.Entity<Product>()
                .HasData(product01, product02, product03, product04, product05, product06, product07, product08, product09, product10, product11, product12, product13,
                product14, product15, product16, product17, product18, product19, product20);
        }
    }
}
