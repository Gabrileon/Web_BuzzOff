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
