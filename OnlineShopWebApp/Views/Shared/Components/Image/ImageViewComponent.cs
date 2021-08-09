using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Db.Models;
using System;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.ImageViewComponent
{
    public class ImageViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache cache;

        public ImageViewComponent(UserManager<User> userManager, IMemoryCache cache)
        {
            this.userManager = userManager;
            this.cache = cache;
        }

        public IViewComponentResult Invoke()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            string userImage = string.Empty;
            if (!cache.TryGetValue(user.UserName, out userImage))
            {
                if (user.Image == null || user.Image == "")
                {
                    cache.Set(user.UserName, "/img/profile.webp", new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
                    return View("Image", "/img/profile.webp");
                }
                cache.Set(user.UserName, user.Image, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
            }
            if (user.Image==null)
            {
                return View("Image", "/img/profile.webp");
            }
            return View("Image", user.Image);
        }
    }
}
