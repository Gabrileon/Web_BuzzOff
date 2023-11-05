﻿using Azure;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuzzOff.Controllers
{
    public class DenouncementController : Controller
    {
        public IActionResult Index()
        {
            var model = new UsersModel();
            List<IUser> Usuario = UserDAO.GetAll();
            foreach (var user in Usuario)
            {
               // model.Users.Add(new UserModel()
               // {
               //     Id = user.Id,
               //     CPF = user.CPF,
               //     Name = user.Name,
               //     Email = user.Email,
               //     AccessLevel = user.AccessLevel,
               // });

                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
            }

            // Redireciona para o arquivo Index.cshtml na pasta Users
            return View(model);

        }
       
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(DenouncementModel model)
        {
            Console.WriteLine("DenouncementModel: ");
            Console.WriteLine(model);


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(UserModel model)
        {

            return RedirectToAction("Index");
        }
    }
}
