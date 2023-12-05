using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add()
        {
            ViewBag.Message = "Informe sobre a visita";
            return View();
        }
        [HttpPost]
        public IActionResult Add(VisitModel model, bool isFocus)
        {
            model.Id = Convert.ToInt32(HttpContext.User.Claims.First().Value); 
            model.DateVisit = DateTime.Now;
            VisitDAO.Insert(model);
            if (isFocus)
            {
                // Direciona a tela de confirmação do foco
                return RedirectToAction("FocusConfirmed");

            }
            else
            {
                //Retorna a listagem de visitas feitas pelo agente
                return RedirectToAction("Visit","Index");
            }
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
