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
            var model = new UsersModel();
            List<IUser> Usuario = UserDAO.GetAll();
            foreach (var user in Usuario)
            {
                model.Users.Add(new UserModel()
                {
                    Id = user.Id,
                    CPF = user.CPF,
                    Name = user.Name,
                    CPF = user.CPF,
                    Email = user.Email,
                    AccessLevel = user.AccessLevel,
                });
            }
            // Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);

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
        [HttpPost]
        public IActionResult Update(UserModel model)
        {

            return RedirectToAction("Index");
        }
    }
}
