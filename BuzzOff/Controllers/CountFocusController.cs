using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class CountFocusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
