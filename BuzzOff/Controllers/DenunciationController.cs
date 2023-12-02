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
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using static System.Net.Mime.MediaTypeNames;

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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DenunciationAddressModel model, IFormFile image)
        {
            var address = model.Address;
            address.Id = AddressDAO.Insert(address);

            var denunciation = model.Denunciation;
            denunciation.Address = address;
            denunciation.IdInformer = Convert.ToInt32(HttpContext.User.Claims.First().Value);

            byte[] convertedMedia;
            string nameImage;


            if (image != null && image.Length > 0)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    convertedMedia = memoryStream.ToArray();
                    nameImage = image.FileName;

                    denunciation.Media = convertedMedia;
                    denunciation.MediaName = nameImage;
                }

            }

            denunciation.Stage = Common.Others.MyEnuns.DenunciationStage.NotAnswered;
            denunciation.DataDenunciation = DateTime.Now;

            DenunciationDAO.Insert(denunciation);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(DenunciationModel model)
        {

            return RedirectToAction("Home", "Index");
        }

        [HttpPost]
        public IActionResult Delete(DenunciationModel model)
        {
            model.IdInformer = Convert.ToInt32(HttpContext.User.Claims.First().Value);
            model.Address.Id = AddressDAO.Insert(model.Address);
            DenunciationDAO.Delete(model.Id);
            return RedirectToAction("Index");
        }

        public IActionResult GetByUserId()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First().Value);
            var denunciations = DenunciationDAO.GetByInformerId(userId);

            var model = new DenunciationsModel()
            {
                Denunciations = denunciations
            };

            ViewBag.Message = "Minhas denúncias";

            return View(model);
        }

        public IActionResult SeeDenunciation(int id)
        {
            ViewBag.Message = "Acompanhar denúncia";
            var model = new DenunciationAddressModel(DenunciationDAO.GetOne(id));
            return View(model);
        }
    }
}
