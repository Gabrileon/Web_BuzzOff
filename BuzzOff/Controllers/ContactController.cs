using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
