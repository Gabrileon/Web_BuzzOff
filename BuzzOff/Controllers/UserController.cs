using Business.Generics;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            UserDAO.Insert(model);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(UserDAO.GetOne(id));
        }

        [HttpPost]
        public IActionResult Update(UserModel model)
        {
            UserDAO.Update(model);
            return RedirectToAction("Index");
        }
    }
}
