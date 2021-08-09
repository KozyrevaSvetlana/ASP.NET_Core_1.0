using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class FavoritesDbRepository : IFavoritesRepository
    {
        private readonly DatabaseContext databaseContext;
        public FavoritesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Favorites> AllFavorites
        {
            get
            {
                return databaseContext.Favorites.ToList();
            }
        }

        public void Add(Product product, string UserId)
        {
            var userFavoritesList = TryGetByUserId(UserId);
            if (userFavoritesList == null)
            {
                AddNewFavorite(product, UserId);
            }
            else
            {
                var userCartItem = userFavoritesList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userFavoritesList.Items.Add(product);
                }
            }
            databaseContext.SaveChanges();
        }

        public void Clear(string UserId)
        {
            var result = TryGetByUserId(UserId);
            databaseContext.Remove(result);
            databaseContext.SaveChanges();
        }

        public void DeleteItem(Guid id, string UserId)
        {
            var favorite = TryGetByUserId(UserId);
            favorite.Items.RemoveAll(x => x.Id == id);
            databaseContext.SaveChanges();
        }

        public Favorites TryGetByUserId(string UserId)
        {
            return databaseContext.Favorites.Include(x => x.Items).FirstOrDefault(x => x.UserId == UserId);
        }
        private void AddNewFavorite(Product product, string userId)
        {
            var newCart = new Favorites
            {
                UserId = userId,
                Items = new List<Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Favorites.Add(newCart);
            databaseContext.SaveChanges();
        }
    }
}
