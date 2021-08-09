using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IOrdersRepository ordersRepository;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;

        public UsersController(UserManager<User> userManager, IOrdersRepository ordersRepository, 
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.ordersRepository = ordersRepository;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var allUsers = userManager.Users;
            return View(mapper.Map<IEnumerable<UserViewModel>>(allUsers));
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Register register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
                return View("AddUser", register);
            }
            if (ModelState.IsValid)
            {
                User newUser = new User { UserName = register.Name, Email= register.Name };
                var result = userManager.CreateAsync(newUser, register.Password).Result;
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("AddUser", register);
                    }
                }
                var resultRole = userManager.AddToRoleAsync(newUser, "user").Result;
                if (resultRole.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, "user").Wait();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult UserInfo(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(mapper.Map<UserViewModel>(user));
        }

        public ActionResult ChangePassword(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            return View(mapper.Map<UserViewModel>(user).Login);
        }

        [HttpPost]
        public ActionResult AddNewPassword(Login login, string CheckPassword, string userName, string oldPassword)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            bool validPassword = userManager.CheckPasswordAsync(user, oldPassword).Result;
            if (!validPassword)
            {
                ModelState.AddModelError("", "Старый пароль указан неверно");
                return View("ChangePassword", login);
            }
            if (login.Password != CheckPassword)
            {
                ModelState.AddModelError("", "Пароли не совпадают");
                return View("ChangePassword", login);
            }
            var result = userManager.ChangePasswordAsync(user, oldPassword, login.Password).Result;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("ChangePassword", login);
                }
            }
            userManager.ChangePasswordAsync(user, oldPassword, login.Password).Wait();
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var orders = ordersRepository.GetOrdersByUserId(user.UserName);
            if (orders.Count > 0)
            {
                string ordersNumbers = "";
                foreach (var order in orders)
                {
                    ordersNumbers += $"{order.Number}, ";
                }
                ModelState.AddModelError("", $"Невозможно удалить пользователя {user.UserName}. " +
                    $"У него есть заказы: {ordersNumbers.Substring(0, ordersNumbers.Length - 2)}.");
                var allUsers = userManager.Users;
                return View("Index", mapper.Map<IEnumerable<UserViewModel>>(allUsers));
            }
            var result = userManager.DeleteAsync(user).Result;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return RedirectToAction("Index");
                }
            }
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Index");
        }
        public ActionResult EditForm(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            ViewBag.Id = user.Id;
            return View(mapper.Map<UserViewModel>(user).Contacts);
        }
        [HttpPost]
        public ActionResult ChangeContacts(UserContactViewModel editUser, string userId)
        {
            var user = userManager.FindByIdAsync(userId).Result;
            user.ContactsName = editUser.ContactsName;
            user.Surname = editUser.Surname;
            user.Adress = editUser.Adress;
            user.PhoneNumber = editUser.PhoneNumber;
            user.Email = editUser.Email;
            var result = userManager.UpdateAsync(user).Result;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("EditForm", editUser);
                }
            }
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction("Index");
        }
        public ActionResult Roles(string userName)
        {
            User user = userManager.FindByNameAsync(userName).Result;
            var allRoles = roleManager.Roles;
            var model = new ChangeRoleViewModel();
            model.UserName = user.UserName;
            model.AllRoles = mapper.Map<List<RoleViewModel>>(allRoles);
            var userRoles = new List<RoleViewModel>();
            try
            {
                var userRolesDb = userManager.GetRolesAsync(user).Result;
                model.UserRoles = userRolesDb.Select(x => new RoleViewModel { Name = x }).ToList();

            }
            catch (Exception)
            {
                userRoles = new List<RoleViewModel>();
            }
            return View(model);
        }
        public ActionResult Edit(string userName, List<string> roles)
        {
            var allRoles = roleManager.Roles;
            if (roles.Count == 0)
            {
                ModelState.AddModelError("", "Вы не выбрали роль");
                var model = new ChangeRoleViewModel();
                model.UserName = userName;
                model.AllRoles = mapper.Map<List<RoleViewModel>>(allRoles);
                return View("Roles", model);
            }
            var user = userManager.FindByNameAsync(userName).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);
            userManager.RemoveFromRolesAsync(user, removedRoles).Wait();
            userManager.AddToRolesAsync(user, addedRoles).Wait();
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction("Index");
        }
    }
}
