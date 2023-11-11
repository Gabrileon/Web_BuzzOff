using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class VisitSolicitationController : Controller
    {
        public IActionResult Index()
        {
            var model = new VisitSolicitationsModel
            {
                visitSolicitations = VisitSolicitationDAO.GetAll()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(VisitSolicitationModel model)
        {
            VisitSolicitationDAO.Insert(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(VisitSolicitationModel model)
        {
            VisitSolicitationDAO.Insert(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(VisitSolicitationModel model)
        {
            VisitSolicitationDAO.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}
