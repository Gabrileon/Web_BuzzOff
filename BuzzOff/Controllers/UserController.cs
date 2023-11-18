using Business.Generics;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BuzzOff.Controllers
{
    [Authorize]
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
        public IActionResult Update(int id)
        {
            UserModel model = UserDAO.GetOne(id) as UserModel;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UserModel model)
        {
            UserDAO.Update(model);
            return RedirectToAction("Index");
        }
    }
}
