using Business.Generics;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace BuzzOff.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UsersModel model = new()
            {
                Users = UserDAO.GetAll()
            };
            // Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);
        }
        public IActionResult Update()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First().Value);
            var user = UserDAO.GetOne(id);
            var model = new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AccessLevel = user.AccessLevel,
                CPF = user.CPF
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(UserModel model)
        {
            UserDAO.Update(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePassword(string cpf, string name, string newPassword)
        {
            UserDAO.UpdatePassword(cpf, name, newPassword);
            return RedirectToAction("Index", "Login");
        }
    }
}
