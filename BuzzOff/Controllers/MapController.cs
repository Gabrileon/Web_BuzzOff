using BuzzOff.Models;
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
            ViewBag.Neighborhood = new List<CountFocusModel>(); 
            foreach (var model in ViewBag.Neighborhood) 
            { 
                ViewBag.Neighborhood.Add()
            }
            return View();
        }
    }
}
