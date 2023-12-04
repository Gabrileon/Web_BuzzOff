using Business.Repository.DAO;
using BuzzOff.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BuzzOff.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Mapa de Focos";
            var model = new CountFocusesModel();
            model.TotalFocus.Add(CountFocusDAO.AmountByErradicated(false));
            model.CountFocus = CountFocusDAO.CountAllErraticated(false);

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

            ViewBag.MapData = data;
            return View(model);
        }
    }
}
