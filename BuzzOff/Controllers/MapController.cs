using Business.Generics;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Olá combatente!";
                     
            return View();
        }

        public IActionResult ShowNeighborhood() 
        {
            var model = new List<CountFocusModel>();
            foreach (var focus in CountFocusDAO.CountByErraticatedAndNeighborhood(false))
            {
                model.Add(new CountFocusModel(focus));
            }
            return View(model);
        }
    }
}
