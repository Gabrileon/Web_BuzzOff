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
            foreach (var user in Business.Generics.User.Users)
            {
                model.Users.Add(new UserModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    AccessLevel = user.AccessLevel,
                });
            }

            // Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);
        }
    }
}
