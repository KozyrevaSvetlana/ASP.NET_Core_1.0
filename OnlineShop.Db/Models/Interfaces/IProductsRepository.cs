using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product GetProductById(Guid id);
        void Remove(Guid id);
        void Restore(Guid id);
        void Edit(Product editProduct);
        int GetCount();
        void Add(Product newProduct);
        List<Product> SeachProduct(string[] seachResults);
    }
}