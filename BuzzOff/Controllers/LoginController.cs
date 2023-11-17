using Business.Repository.DAO;
<<<<<<< HEAD
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
=======
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
>>>>>>> main

namespace BuzzOff.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
        public IActionResult TryVerification(string name, string password)
        {
            var model = UserDAO.GetOne(name, password);
            if (!model.ToString().IsNullOrEmpty())
            {
                ViewBag.loggedUser = model;
            return RedirectToAction("Index", "User");                    
            }
            else
            {
                return RedirectToAction("Index");
            }
=======

        [HttpPost]
        public async Task<IActionResult> TryVerification(LoggedUserModel model)
        {
            var user = UserDAO.GetOne(model.Name, model.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim("AccessLevel", user.AccessLevel.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties()
                {
                    IsPersistent = model.rememberMe
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Credenciais inválidas");
            
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            UserDAO.Insert(model);
            return RedirectToAction("Index");
>>>>>>> main
        }
    }
}
