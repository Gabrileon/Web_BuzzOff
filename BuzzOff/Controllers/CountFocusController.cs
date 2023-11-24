using Business.Repository.DAO;
using BuzzOff.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class CountFocusController : Controller
    {
        public IActionResult Index()
        {
            int countTotal = CountFocusDAO.AmountByErradicated(false);            
            var model = new CountFocusesModel();
            model.TotalFocus.Add(countTotal);
            foreach (var focus in CountFocusDAO.CountByErraticatedAndNeighborhood(false))
            {
                model.CountFocus.Add(new CountFocusModel(focus));                
            }
            return View(model);
        }
    }
}
