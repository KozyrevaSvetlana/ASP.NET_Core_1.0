using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewRole(IdentityRole newRole)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = newRole.Name };
                var result = roleManager.CreateAsync(role).Result;
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("AddRole", newRole);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRole(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;
            var roles = roleManager.Roles;
            var usersInRole = userManager.GetUsersInRoleAsync(role.Name).Result;
            if (usersInRole.Count>0)
            {
                string users = "";
                foreach (var user in usersInRole)
                {
                    users += $"{user.UserName}, ";
                }
                ModelState.AddModelError("", $"Роль невозможно удалить. Она используется {users.Substring(0, users.Length-2)}.");
                return View("Index", roles);
            }
            roleManager.DeleteAsync(role).Wait();
            return RedirectToAction("Index");
        }
        public ActionResult EditRole(string id)
        {
            var role = roleManager.FindByIdAsync(id).Result;
            return View(mapper.Map<RoleViewModel>(role));
        }
        [HttpPost]
        public IActionResult ChangeRole(string newName, string roleId)
        {
            var role = roleManager.FindByIdAsync(roleId).Result;
            if (newName == null)
            {
                ModelState.AddModelError("", "Не заполнено новое имя");
                return View("EditRole", role);
            }
            if (newName.Length < 2 || newName.Length > 50)
            {
                ModelState.AddModelError("", "Имя должно быть не менее 2 символов и не более 50 символов");
                return View("EditRole", role);
            }
            role.Name = newName;
            var result = roleManager.UpdateAsync(role).Result;
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("EditRole", role);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
