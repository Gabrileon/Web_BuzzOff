using Business.Generics;
using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            foreach (var focus in CountFocusDAO.CountAllErraticated(false))
            {
                model.CountFocus.Add(new CountFocusModel(focus));

                var data = new List<MapParameterModel>();
                foreach (var bairro in CoordinateDAO.GetAll())
                {
                    data.Add(new MapParameterModel()
                    {
                        Id = bairro.Id,
                        Nome = bairro.Neighborhood,
                        Latitude = bairro.Latitude.ToString(new CultureInfo("en-US")),
                        Longitude = bairro.Longitude.ToString(new CultureInfo("en-US")),
                        Count = CountFocusDAO.CountByErraticatedAndNeighborhood(false, bairro.Neighborhood).Counts,
                    });
                }              
            }
            return View(model);
        }
    }
}
