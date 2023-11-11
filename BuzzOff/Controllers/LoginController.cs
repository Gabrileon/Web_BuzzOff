using Business.Repository.DAO;
using Common.Interfaces;
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
            var model = UserDAO.GetOne(name, password);
            if (model != null)
            {
                ViewBag.loggedUser = model;
            return RedirectToAction("Index", "User");                    
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
