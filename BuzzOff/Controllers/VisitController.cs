using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class VisitController : Controller
    {
        //public IActionResult Index()
        //{
        //    DenunciationsModel model = new()
        //    {
        //        Denunciations = DenunciationDAO.GetAllPendent()
        //    };
        //    return View(model);
        //}
        public IActionResult Add()
        {
            ViewBag.Message = "Informe sobre a visita";
            return View();
        }
        [HttpPost]
        public IActionResult Add(VisitModel model, bool isFocus)
        {
            model.DateVisit = DateTime.Now;
            VisitDAO.Insert(model);
            if (isFocus)
            {
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
