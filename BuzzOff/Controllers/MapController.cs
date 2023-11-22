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
       
    }
}
