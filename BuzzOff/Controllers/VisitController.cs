﻿using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Others;
using Microsoft.AspNetCore.Mvc;
using Common.Others;

namespace BuzzOff.Controllers
{
    [Authorize("Agent")]
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            var id = Convert.ToInt32(HttpContext.User.Claims.First().Value);
            var model = new VisitsModel()
            {
                Visits = VisitDAO.GetAllVisitsAgent(id),
            };
            return View(model);
        }
        public IActionResult Add(int id)
        {
            ViewBag.Message = "Informe sobre a visita";
            return View();
        }
        [HttpPost]
        public IActionResult Add(VisitModel model, bool isFocus, int id)
        {
            model.IdAgent = Convert.ToInt32(HttpContext.User.Claims.First().Value);
            model.Denunciation = DenunciationDAO.GetOne(id);
            model.DateVisit = DateTime.Now;
            model.Denunciation.Stage = MyEnuns.DenunciationStage.Pendent;
            DenunciationDAO.Update(model.Denunciation);
            VisitDAO.Insert(model);
            if (isFocus)
            {

                // Retorna ao método de adição na tabela DengueFocus

            }
                return RedirectToAction("Visit", "Index");
        }
        public IActionResult FocusConfirmed(int idVisit)
        {
            return View(idVisit);
        }
        [HttpPost]
        public IActionResult InsertFocusDengueAndSolicitation(SolicitationModel model, bool isEradicated, int idVisit)
        {
            var visits = VisitDAO.GetOne(idVisit);
            SolicitationDAO.Insert(model);
            var dengueFocus = new DengueFocusModel()
            {
                IsEradicated = isEradicated,
                Priority = model.Priority,
                Address = visits.Denunciation.Address,
                Visit = visits,
                Type = visits.Denunciation.FocusType
            };
            DengueFocusDAO.Insert(dengueFocus);
            return RedirectToAction("Visit", "Index");
        }
    }
}
