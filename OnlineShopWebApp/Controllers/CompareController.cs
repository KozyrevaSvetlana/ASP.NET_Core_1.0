using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICompareRepository compareRepository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository, UserManager<User> userManager, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var compareCart = compareRepository.TryGetByCompareId(user.UserName);
            return View(mapper.Map<CompareViewModel>(compareCart));
        }

        public IActionResult Add(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var product = productsRepository.GetProductById(id);
            compareRepository.Add(product, user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            compareRepository.Clear(user.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            compareRepository.DeleteItem(id, user.UserName);
            return RedirectToAction("Index");
        }
    }
}
