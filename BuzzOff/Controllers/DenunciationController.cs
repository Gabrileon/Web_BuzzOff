﻿using Azure;
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
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Add(DenunciationAddressModel model)
        {
            var address = model.GetAddressModel();
            address.Id = AddressDAO.Insert(address);

            var denunciation = model.GetDenunciantionModel();
            denunciation.Address = address;
            denunciation.IdInformer = Convert.ToInt32(HttpContext.User.Claims.First().Value);

            DenunciationDAO.Insert(denunciation);
            return RedirectToAction("Index");
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









    

    }
}
