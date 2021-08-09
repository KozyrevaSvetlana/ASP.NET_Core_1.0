using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.TestProject
{
    public class ProductsRepositoryTest: IProductsRepository
    {
        private readonly DatabaseContext productsDbContext;
        public ProductsRepositoryTest(DatabaseContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }
        public ProductsRepositoryTest()
        {
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return productsDbContext.AllProducts.Include(x => x.Images).ToList();
            }
        }

        public Product GetProductById(Guid id)
        {
            return productsDbContext.AllProducts.Include(x => x.Images).FirstOrDefault(p => p.Id == id);
        }

        public void DeleteItem(Guid id)
        {
            var deleteProduct = productsDbContext.AllProducts.FirstOrDefault(p => p.Id == id);
            productsDbContext.AllProducts.Remove(deleteProduct);
            productsDbContext.SaveChanges();
        }
        public void Edit(Product editProduct)
        {
            var product = AllProducts.FirstOrDefault(p => p.Id == editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
            product.Images = editProduct.Images;
            productsDbContext.SaveChanges();
        }
        public int GetCount()
        {
            return productsDbContext.AllProducts.Count();
        }
        public void Add(Product newProduct)
        {
            productsDbContext.AllProducts.Add(newProduct);
            productsDbContext.SaveChanges();
        }

        public List<Product> SeachProduct(string[] seachResults)
        {
            var resultList = new List<Product>();

            foreach (var word in seachResults)
            {
                resultList = productsDbContext.AllProducts.Where(x => x.Name.ToLower().Contains(word.ToLower())).Include(x => x.Images).ToList();
            }
            return resultList.Distinct().ToList();
        }
    }
}
