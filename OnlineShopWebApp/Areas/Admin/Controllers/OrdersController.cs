using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public OrdersController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<OrderViewModel>>(ordersRepository.AllOrders));
        }
        public IActionResult OrderForm(int number)
        {
            var order = ordersRepository.GetOrderByNumber(number);
            ViewData["Statuses"] = InfoStatusOrderViewModel.GetAllStatuses();
            return View(mapper.Map<OrderViewModel>(order));
        }
        public IActionResult EditOrder(int number, string status)
        {
            ordersRepository.Edit(number, MappingProfile.GetStatus(status));
            return RedirectToAction("Index");
        }
        public ActionResult DeleteOrder(int number)
        {
            ordersRepository.Delete(number);
            return RedirectToAction("Index");
        }
    }
}
