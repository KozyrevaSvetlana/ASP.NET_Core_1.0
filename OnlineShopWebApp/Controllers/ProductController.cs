using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository products;
        private readonly IMapper mapper;

        public ProductController(IProductsRepository products, IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }

        public ActionResult Index(Guid id)
        {
            var result = products.GetProductById(id);
            return View(mapper.Map<ProductViewModel>(result));
        }

        [HttpPost]
        public IActionResult Find(string result)
        {
            if (result != null)
            {
                TempData["Result"] = result;
                var searchResult = products.SeachProduct(result.Split());
                return View(mapper.Map<List<ProductViewModel>>(searchResult));
            }
            return View();
        }
        
    }
}
