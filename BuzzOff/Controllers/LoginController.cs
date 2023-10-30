using Business.Repository.DAO;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TryVerification(string name, string password)
        {
            if (UserDAO.GetOne(name, password) != null)
            {
            return RedirectToAction("Index", "User");                    
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
