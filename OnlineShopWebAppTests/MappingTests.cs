using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineShopWebAppTests
{
    [TestClass]
    public class MappingTests
    {
        Guid id;
        List<Image> images;
        List<CartItem> items;
        Product productDb;
        Cart cart;

        //данный метод запускается перед каждым запуском теста
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize");
            id = Guid.NewGuid();
            cart = new Cart() { Id = 1, UserId = "User" };
            images = new List<Image>() { new Image() { Id = Guid.NewGuid(), Url = "/img/Products/1.jpg", ProductId = id } };
            productDb = new Product() { Id = id, Name = "Product1", Description = "Description1", Images = images };
            items = new List<CartItem>() { new CartItem() { Id = 1, Amount = 1, Product = productDb } };
        }
        [TestMethod]
        public void ToProductViewModels_ListProducts_ListProductViewModels()
        {
            //arrange настройка
            List<Product> products = new List<Product>();
            products.Add(productDb);
            IEnumerable<Product> productsTest = products;
            var expected = Mapping.ToProductViewModels(productsTest);

            //act выполнить действия
            var actual = Mapping.ToProductViewModels(productsTest);

            //assert результат
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id, "MappingTests ToProductViewModels Id");
                Assert.AreEqual(expected[i].Name, actual[i].Name, "MappingTests ToProductViewModels Name");
                Assert.AreEqual(expected[i].Cost, actual[i].Cost, "MappingTests ToProductViewModels Cost");
                Assert.AreEqual(expected[i].Description, actual[i].Description, "MappingTests ToProductViewModels Description");
                Assert.AreEqual(expected[i].Image, actual[i].Image, "MappingTests ToProductViewModels Image");
                CollectionAssert.AreEqual(expected[i].UploadedFile, actual[i].UploadedFile, "MappingTests ToProductViewModels UploadedFile");
                CollectionAssert.AreEqual(expected[i].Images, actual[i].Images, "MappingTests ToProductViewModels Images");
            }
        }
        [TestMethod]
        public void ToProductViewModel_Product_ProductViewModel()
        {
            var expected = Mapping.ToProductViewModel(productDb);

            var actual = Mapping.ToProductViewModel(productDb);

            Assert.AreEqual(expected.Id, actual.Id, "MappingTests ToProductViewModel Id");
            Assert.AreEqual(expected.Name, actual.Name, "MappingTests ToProductViewModel Name");
            Assert.AreEqual(expected.Description, actual.Description, "MappingTests ToProductViewModel Description");
        }
        [TestMethod]
        public void ToCartViewModel_Cart_CartViewModel()
        {
            var expected = Mapping.ToCartViewModel(cart);

            var actual = Mapping.ToCartViewModel(cart);

            Assert.AreEqual(expected.Id, actual.Id, "MappingTests ToCartViewModel Id");
            Assert.AreEqual(expected.Amount, actual.Amount, "MappingTests ToCartViewModel Amount");
            Assert.AreEqual(expected.UserId, actual.UserId, "MappingTests ToCartViewModel UserId");
            Assert.AreEqual(expected.Cost, actual.Cost, "MappingTests ToCartViewModel Cost");
            for (int i = 0; i < cart.Items.Count; i++)
            {
                CollectionAssert.AreEqual(expected.Items, expected.Items, "MappingTests ToCartViewModel Items");
            }
        }
        [TestMethod]
        public void ToCartItemViewModels_ListCartItem_ListCartItemViewModel()
        {
            var expected = Mapping.ToCartItemViewModels(items);

            var actual = Mapping.ToCartItemViewModels(items);

            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(expected[i].Amount, actual[i].Amount, "MappingTests ToCartItemViewModels Amount");
                Assert.AreEqual(expected[i].Product.Id, actual[i].Product.Id, "MappingTests ToCartItemViewModels Product.Id");
                Assert.AreEqual(expected[i].Product.Name, actual[i].Product.Name, "MappingTests ToCartItemViewModels Product.Name");
                Assert.AreEqual(expected[i].Product.Description, actual[i].Product.Description, "MappingTests ToCartItemViewModels Product.Description");
                Assert.AreEqual(expected[i].Product.Cost, actual[i].Product.Cost, "MappingTests ToCartItemViewModels Product.Cost");
                Assert.AreEqual(expected[i].Product.Image, actual[i].Product.Image, "MappingTests ToCartItemViewModels Product.Image");
                Assert.AreEqual(expected[i].Cost, actual[i].Cost, "MappingTests ToCartItemViewModels Cost");
            }
        }
    }
}
