using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider imagesProvider;
        private readonly IMapper mapper;

        public ProductsController(IProductsRepository productsRepository, ImagesProvider imagesProvider, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<ProductViewModel>>(productsRepository.AllProducts));
        }
        public IActionResult Description(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(mapper.Map<ProductViewModel>(result));
        }
        public ActionResult EditForm(Guid id)
        {
            var result = productsRepository.GetProductById(id);
            return View(mapper.Map<ProductViewModel>(result));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductViewModel editProduct)
        {
            var validResult = editProduct.IsValid();
            if (validResult.Count != 0)
            {
                foreach (var errors in validResult)
                {
                    ModelState.AddModelError("", errors);
                }
            }
            if (ModelState.IsValid)
            {
                var imagesPaths = imagesProvider.SafeFiles(editProduct.UploadedFile, ImageFolders.Products);
                if (imagesPaths.Count==0)
                {
                    foreach (var item in editProduct.Images)
                    {
                        imagesPaths.Add(item);
                    }
                }
                var images = mapper.Map<List<Image>>(imagesPaths);
                var product = mapper.Map<Product>(editProduct);
                product.Images = images;
                productsRepository.Edit(product);
                return RedirectToAction("Index");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(Guid id)
        {
            productsRepository.Remove(id);
            return RedirectToAction("Index");
        }
        public ActionResult Restore(Guid id)
        {
            productsRepository.Restore(id);
            return RedirectToAction("Index");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewProduct(AddProductViewModel newProduct)
        {
            var errorsResult = newProduct.IsValid();
            if (errorsResult.Count != 0)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
                return View("AddProduct", newProduct);
            }
            if (ModelState.IsValid)
            {
                var imagesPaths = imagesProvider.SafeFiles(newProduct.UploadedFiles, ImageFolders.Products);
                if (imagesPaths.Count==0)
                {
                    imagesPaths.Add("/img/Products/1.jpg");
                }
                var images = mapper.Map<List<Image>>(imagesPaths);
                var product = mapper.Map<Product>(newProduct);
                product.Images = images;
                productsRepository.Add(mapper.Map<Product>(product));
                return RedirectToAction("Index");
            }
            return View("AddProduct", newProduct);
        }
    }
}
