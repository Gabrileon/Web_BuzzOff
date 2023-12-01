using Business.Repository.DAO;
using BuzzOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class VisitController : Controller
    {
        public IActionResult Index()
        {
            VisitDAO.GetAllVisitsAgent(Convert.ToInt32(HttpContext.User.Claims.First().Value));
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(VisitModel model, bool isFocus)
        {
            VisitDAO.Insert(model);
            if (isFocus)
            {
                // Retorna ao método de adição na tabela DengueFocus
                return RedirectToAction("Home","Index");

            }
            else
            {
                //Retorna a listagem de visitas feitas pelo agente
                return RedirectToAction("Visit","Index");
            }
        }

    }
}
