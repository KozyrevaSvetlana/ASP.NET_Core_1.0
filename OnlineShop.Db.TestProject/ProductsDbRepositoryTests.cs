using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using Xunit;

namespace OnlineShop.Db.TestProject
{
    public class ProductsDbRepositoryTests
    {
        private readonly IProductsRepository productsRepository;
        ProductsDbRepositoryTests(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        [Fact]
        public void AllProducts__ReturnsAllProducts()
        {
            //Microsoft.EntityFrameworkCore.InMemory
               var options = new DbContextOptionsBuilder<DatabaseContextTests>().Use
                .UseInMemoryDatabase(databaseName: "ProductsDbRepository")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DatabaseContextTests(options))
            {
                context.AllProducts.Add(new Product()
                {
                    Id = Guid.Parse("a3f432a9-17a0-4307-984b-290611a248f5"),
                    Cost = 11426,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Name = "Пистолетик",
                });
                context.AllProducts.Add(new Product()
                {
                    Id = Guid.Parse("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                    Cost = 11426,
                    Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim",
                    Name = "Шапка",
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DatabaseContextTests(options))
            {
                var expected = productsRepository.AllProducts;
                var sut = new ProductsRepositoryTest(context);

                var actual = sut.AllProducts;

                //Assert
                Assert.AreEqual(expected, actual, "AllProducts expected {0}, but {1}", expected, actual);
            }
        }
    }
}
