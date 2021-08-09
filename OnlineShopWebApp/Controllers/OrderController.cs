using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersWithoutUserRepository, UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.cartsRepository = cartsRepository;
            ordersRepository = ordersWithoutUserRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var userName = Request.Cookies["id"];
            var cart = new Cart();
            if(userName==null)
            {
                cart = cartsRepository.TryGetByUserId(user.UserName);
            }
            else
            {
                cart = cartsRepository.TryGetByUserId(userName);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Accept(string Comment, UserContactViewModel userContacts)
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var errorsResult = userContacts.IsValid();
            if (errorsResult != null)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                var order = new OrderViewModel();
                order.AddContacts(user.UserName, userContacts, new InfoStatusOrderViewModel(DateTime.Now), Comment);
                var cart = new Cart();
                cart = cartsRepository.TryGetByUserId(user.UserName);
                if(cart==null)
                {
                    var userName = Request.Cookies["id"];
                    cart = cartsRepository.TryGetByUserId(userName);
                    Response.Cookies.Delete("id");
                }
                order.Products = mapper.Map<List<CartItemViewModel>>(cart.Items);
                order.Number = ordersRepository.GetLastNumber();
                ordersRepository.AddOrder(mapper.Map<Order>(order), cart);
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public IActionResult Result()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var order = ordersRepository.GetLastOrder(user.UserName);
            return View(mapper.Map<OrderViewModel>(order));
        }
    }
}
