using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IFavoritesRepository
    {
        IEnumerable<Favorites> AllFavorites { get; }
        Favorites TryGetByUserId(string UserId);
        void Add(Product product, string UserId);
        void DeleteItem(Guid id, string UserId);
        void Clear(string UserId);
    }
}