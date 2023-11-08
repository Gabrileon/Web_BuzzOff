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
            var model = new VisitSolicitationsModel();

            List<IVisitSolicitation> list = VisitSolicitationDAO.GetAll();

            foreach (IVisitSolicitation result in list)
            {
                model.visitSolicitations.Add(new VisitSolicitationModel()
                {
                    Id = result.Id,
                    Solicitation = result.Solicitation,
                    Visit = result.Visit,
                });
            }
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
    }
}
