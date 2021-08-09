using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Cart> AllCarts
        {
            get
            {
                return databaseContext.Carts;
            }
        }
        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.UserId == userId);
        }
        public int GetAllAmounts(string userId)
        {
            var userCart = TryGetByUserId(userId);
            return userCart?.Items?.Sum(x => x.Amount) ?? 0;
        }
        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Amount = 1,
                            Product = product,
                            Cart = newCart
                        }
                    };
                databaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = existingCart
                    });
                }
            }
            databaseContext.SaveChanges();
        }

        public void ChangeAmount(Product product, int sign, string userId)
        {
            var userCart = TryGetByUserId(userId);
            var userCartItem = userCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            switch (sign)
            {
                case 1:
                    userCartItem.Amount++;
                    break;
                case -1:
                    if (userCartItem.Amount > 1)
                    {
                        userCartItem.Amount--;
                    }
                    else
                    {
                        userCart.Items.Remove(userCartItem);
                    }
                    break;
            }
            databaseContext.SaveChanges();
        }

        public void ClearCart(string userId)
        {
            var userCart = TryGetByUserId(userId);
            userCart.Items.ForEach(x => databaseContext.Remove(x));
            databaseContext.Carts.Remove(userCart);
            databaseContext.SaveChanges();
        }
    }
}
