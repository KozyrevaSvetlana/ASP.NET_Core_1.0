using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoritesRepository favoritesRepository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public FavoritesController(IProductsRepository productsRepository, IFavoritesRepository favoritesRepository, UserManager<User> userManager, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.favoritesRepository = favoritesRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var cart = favoritesRepository.TryGetByUserId(user.UserName);
            return View(mapper.Map<FavoritesViewModel>(cart));
        }

        public IActionResult Add(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var product = productsRepository.GetProductById(id);
            favoritesRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            favoritesRepository.Clear(user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            favoritesRepository.DeleteItem(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
