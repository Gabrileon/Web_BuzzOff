using Business.Generics;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Common.Others;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Reflection.Metadata;
using static Common.Others.MyEnuns;

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
        [Authorize("Administrator")]
        public IActionResult CommonUsers()
        {
            UsersModel commonUsers = new()
            {
                Users = UserDAO.GetAllCommons()
            };

            return View(commonUsers);
        }
        [Authorize("Administrator")]
        public IActionResult UpdateAccessLevel(int id)
        {
            List<MyEnuns.Access> access = new()
            {
                MyEnuns.Access.Common,
                MyEnuns.Access.Agent,
                MyEnuns.Access.Administrator
            };
            ViewBag.Access = access;

            var user = UserDAO.GetOne(id);
            UserModel model = new()
            {
                Name = user.Name,
                Email = user.Email,
                AccessLevel = user.AccessLevel,
                CPF = user.CPF,
                Id = user.Id
            };
            return View(model);
        }
        [HttpPost, Authorize("Administrator")]
        public IActionResult UpdateAccessLevel(UserModel model)
        {
            UserDAO.UpdateAccessLevel(model.Id, model.AccessLevel);
            return RedirectToAction("Index", "Home");
        }
    }
}
