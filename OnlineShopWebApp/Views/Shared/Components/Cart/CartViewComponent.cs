using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.FavoritesViewComponent
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public CartViewComponent(ICartsRepository cartsRepository, UserManager<User> userManager, IMapper mapper)
        {
            this.cartsRepository = cartsRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var cart = cartsRepository.TryGetByUserId(user.UserName);
            if (cart==null)
            {
                var userName = Request.Cookies["id"];
                cart =cartsRepository.TryGetByUserId(userName);
            }
            return View("Cart", mapper.Map<CartViewModel>(cart));
        }
    }
}
