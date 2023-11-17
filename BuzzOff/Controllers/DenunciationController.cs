using Business.Repository;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    
    public class DenunciationController : Controller
    {
        public IActionResult Index()
        {
            DenunciationsModel model = new()
            {
                Denunciations = DenunciationDAO.GetAll()
            };
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DenunciationModel model, AddressModel address)
        {
            var idAddress = AddressDAO.Insert(address);
            model.Address = AddressDAO.GetOne(idAddress);
            DenunciationDAO.Insert(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(DenunciationModel model)
        {
            DenunciationDAO.Insert(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(DenunciationModel model)
        {
            DenunciationDAO.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}
