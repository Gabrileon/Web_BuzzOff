using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuzzOff.Controllers
{
    public class CountFocusController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Mapa de Focos";
            int countTotal = CountFocusDAO.AmountByErradicated(false);            
            var model = new CountFocusesModel();
            model.TotalFocus = countTotal;

            public List<ICoordinate> Coordenate { get; set; } = new List<ICoordinate>();

            var data = new List<MapParameterModel>();


            foreach (var focus in CountFocusDAO.CountByErraticatedAndNeighborhood(false))
            {
                model.CountFocus.Add(new CountFocusModel(focus));                
            }

            return View(model);
        }
    }
}
