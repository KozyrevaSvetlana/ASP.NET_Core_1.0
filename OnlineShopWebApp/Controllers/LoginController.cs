using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IOrdersRepository ordersRepository;
        private readonly IEmailSender emailSender;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;
            this.emailSender = emailSender;
        }

        public IActionResult Index(string returnUrl)
        {
            if (returnUrl != null)
            {
                return View(new Login() { ReturnUrl = returnUrl });
            }
            return View();
        }
        public IActionResult RegIndex(string returnUrl)
        {
            if (returnUrl != null)
            {
                return View(new Register() { ReturnUrl = returnUrl });
            }
            return View();
        }

        [HttpPost]
        public IActionResult CheckIn(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    if (login.ReturnUrl == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }
            }
            return View(login);
        }
        [HttpPost]
        public IActionResult Create(Register register)
        {
            if (register.Name == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                User user = new User { UserName = register.Name, Email = register.Name };
                var result = userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    var message = new Message(new string[] { user.Email }, "Регистрация", "Вы удачно зарегистрировались.");
                    emailSender.SendEmail(message);
                    signInManager.SignInAsync(user, false).Wait();
                    if (register.ReturnUrl == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    return Redirect(register.ReturnUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View("RegIndex", register);
                    }
                }
            }
            return View("RegIndex", register);
        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
