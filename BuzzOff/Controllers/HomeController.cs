using BuzzOff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Permissions;

namespace BuzzOff.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var messages = new List<string>()
            {
                "Olá, combatente!",
                "Bzzzzz...",
                "Previna-se!",
                "Combata a dengue",
                "Use repelente",
                "Não deixe água parada"
            };
            
            var message = messages[new Random().Next(messages.Count)];
            

            ViewBag.Message = message;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BeAnAgent()
        {
            ViewBag.Message = "Seja um agente BuzzOff!";
            return View();
        }
    }
}