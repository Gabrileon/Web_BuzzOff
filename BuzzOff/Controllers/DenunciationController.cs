using Azure;
using Business.Generics;
using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuzzOff.Controllers
{
    [Authorize]
    public class DenunciationController : Controller
    {
        public IActionResult Index()
        {
            DenunciationsModel model = new()
            {
                Denunciations = DenunciationDAO.GetAll()
            };
            //Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(DenunciationModel model)
        {
            IUser? user = AuthenticadedUser();

            model.Address.id = AddressDAO.Insert(model.Address);

            DenunciationDAO.Insert(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(DenunciationModel model)
        {

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(DenunciationModel model)
        {
            DenunciationDAO.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IUser? AuthenticadedUser()
        {
            string? UserName = HttpContext.User.Identity?.Name;

            if (UserName != null) {
                return UserDAO.GetOneByName(UserName);
            }

            return null;     
        }

    }
}
