using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IFavoritesRepository favoritesRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly ImagesProvider imagesProvider;
        private readonly IMapper mapper;

        public ProfileController(IFavoritesRepository favoritesRepository, IOrdersRepository ordersRepository,
            UserManager<User> userManager, ImagesProvider imagesProvider, IMapper mapper)
        {
            this.favoritesRepository = favoritesRepository;
            this.ordersRepository = ordersRepository;
            this.userManager = userManager;
            this.imagesProvider = imagesProvider;
            this.mapper = mapper;

    }
        public IActionResult Index()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            return View(mapper.Map<UserViewModel>(userDb));
        }
        public IActionResult Orders()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            var orders = ordersRepository.GetOrdersByUserId(userDb.UserName);
            var userVM = mapper.Map<UserViewModel>(userDb);
            userVM.Orders = mapper.Map<List<OrderViewModel>>(orders);
            return View(userVM);
        }
        public IActionResult Contacts()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            var emptyContacts = mapper.Map<UserViewModel>(user).GetEmptyContacts();
            if (emptyContacts.Count != 0)
            {
                ViewBag.Empty = emptyContacts;
            }
            return View(mapper.Map<UserViewModel>(user));
        }
        public IActionResult AddContacts()
        {
            var user = userManager.GetUserAsync(HttpContext.User).Result;
            return View(mapper.Map<UserViewModel>(user).Contacts);
        }

        [HttpPost]
        public IActionResult AcceptContacts(UserContactViewModel contacts)
        {
            var errorsResult = contacts.IsValid();
            if (errorsResult != null)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                var userDb = userManager.GetUserAsync(HttpContext.User).Result;
                userDb.ContactsName = contacts.ContactsName;
                userDb.Surname = contacts.Surname;
                userDb.Adress = contacts.Adress;
                userDb.PhoneNumber = contacts.PhoneNumber;
                userDb.Email = contacts.Email;
                userManager.UpdateAsync(userDb).Wait();
                return View("Contacts", mapper.Map<UserViewModel>(userDb));
            }
            return View("AddContacts", contacts);
        }
        public IActionResult Favorites()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.Favorites = favoritesRepository.TryGetByUserId(userDb.UserName);
            return View(mapper.Map<UserViewModel>(userDb));
        }
        public IActionResult ChangeProfileImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile File)
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            var imagesPath = imagesProvider.SafeFile(File, ImageFolders.Profiles);
            userDb.Image = imagesPath;
            userManager.UpdateAsync(userDb).Wait();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImage()
        {
            var userDb = userManager.GetUserAsync(HttpContext.User).Result;
            userDb.Image = "/img/profile.webp";
            userManager.UpdateAsync(userDb).Wait();
            return RedirectToAction("Index");
        }
    }
}
