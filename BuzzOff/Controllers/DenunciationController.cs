using Azure;
using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuzzOff.Controllers
{
    public class DenunciationController : Controller
    {
        public IActionResult Index()
        {
            var model = new UserModel();
            List<IDenunciation> Denuncia = DenunciationDAO.GetAll(); 
            foreach (var user in Denuncia)
            {
                model.denunciations.Add(new UserModel()
                {
                    Id = user.Id,
                    CPF = user.CPF,
                    Name = user.Name,
                    Email = user.Email,
                    AccessLevel = user.AccessLevel,
                });
            }
            // Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);

        }
       
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(IDenunciation model)
        {
            DenunciationDAO.Insert(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(UserModel model)
        {

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(IDenunciation model)
        {
            DenunciationDAO.Delete(model.Id);
            return RedirectToAction("Index");
        }

    }
}
