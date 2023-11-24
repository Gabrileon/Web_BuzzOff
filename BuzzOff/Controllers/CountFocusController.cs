using Business.Repository.DAO;
using BuzzOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class CountFocusController : Controller
    {
        public IActionResult Index()
        {
            var model = new CountFocusesModel();
            foreach (var focus in CountFocusDAO.CountByErraticatedAndNeighborhood(false))
            {
                model.CountFocus.Add(focus);
            }
            return View(model);
        }
    }
}
