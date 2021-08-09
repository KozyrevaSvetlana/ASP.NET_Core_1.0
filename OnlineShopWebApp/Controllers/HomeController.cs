using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository products;
        private readonly IMapper mapper;

        public HomeController(IProductsRepository products, IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<ProductViewModel>>(products.AllProducts.Where(p => !p.IsDeleted).ToList()));
        }
    }
}
