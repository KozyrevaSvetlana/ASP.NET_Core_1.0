using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICartsRepository
    {
        IEnumerable<Cart> AllCarts { get; }
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        int GetAllAmounts(string userId);
        void ChangeAmount(Product product, int sign, string userId);
        void ClearCart(string userId);
    }
}