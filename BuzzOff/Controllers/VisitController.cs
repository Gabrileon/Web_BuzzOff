using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Others;
using Microsoft.AspNetCore.Mvc;
using Common.Others;

namespace BuzzOff.Controllers
{
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
            model.IdAgent = Convert.ToInt32(HttpContext.User.Claims.First().Value);
            model.DateVisit = DateTime.Now;
            if (isFocus)
            {
                model.Denunciation.Stage = MyEnuns.DenunciationStage.Pendent;
                VisitDAO.Insert(model);
                // Retorna ao método de adição na tabela DengueFocus
                return RedirectToAction("Solicitation");

            }
            else
            {
                //Retorna a listagem de visitas feitas pelo agente
                return RedirectToAction("Visit","Index");
            }
        }
        public IActionResult Solicitation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFocusDengue(int Id)
        {
            return RedirectToAction("Visit", "Index");
        }
    }
}
