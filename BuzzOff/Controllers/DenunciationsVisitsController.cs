using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class DenunciationsVisitsController : Controller
    {
        public IActionResult Index()
        {
            var model = new DenunciationsVisitsModel();

            List<IDenunciationVisit> list = DenunciationVisitDAO.GetAll();

            foreach (IDenunciationVisit result in list)
            {
                model.denunciationsVisits.Add(new DenunciationVisitModel()
                {
                    Id = result.Id,
                    Denunciation = result.Denunciation,
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
        public IActionResult Add(DenunciationVisitModel model)
        {
            DenunciationVisitDAO.Insert(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(DenunciationVisitModel model)
        {
            DenunciationVisitDAO.Insert(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(DenunciationVisitModel model)
        {
            DenunciationVisitDAO.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}
