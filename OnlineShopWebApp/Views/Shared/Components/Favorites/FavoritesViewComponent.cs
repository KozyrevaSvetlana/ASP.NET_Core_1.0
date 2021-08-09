using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class FavoritesViewComponent : ViewComponent
    {
        private readonly IFavoritesRepository favoritesRepository;
        private readonly UserManager<User> userManager;

        public FavoritesViewComponent(IFavoritesRepository favoritesRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.favoritesRepository = favoritesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var favoritesItemsCount = 0;
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            if (user != null)
            {
                var favorites = favoritesRepository.TryGetByUserId(user.UserName);
                favoritesItemsCount = favorites?.Items.Count ?? 0;
            }
            return View("Favorites", favoritesItemsCount);
        }
    }
}
