using BuzzOff.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Repository.DAO;
namespace BuzzOff.Controllers
{
    public class CountFocusController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Mapa de Focos";
            var model = new CountFocusesModel();
            // Popule o modelo com dados, como você já está fazendo

            // Criar lista de features GeoJSON para cada bairro
            var neighborhoodsGeoJSON = new List<object>();

            foreach (var focus in model.CountFocus)
            {
                var coordinates = GetCoordinatesForNeighborhood(focus.Neighborhood);

                var feature = new
                {
                    type = "Feature",
                    properties = new
                    {
                        name = focus.Neighborhood,
                        focusCount = focus.Counts
                    },
                    geometry = new
                    {
                        type = "Point",
                        coordinates = coordinates
                    }
                };

                neighborhoodsGeoJSON.Add(feature);
            }

            // Converter a lista para um array para uso no JavaScript
            ViewBag.NeighborhoodsGeoJSON = Newtonsoft.Json.JsonConvert.SerializeObject(neighborhoodsGeoJSON);

            return View(model);
        }

        // Método para obter as coordenadas do bairro usando o OpenCage Geocoding API
        private double[] GetCoordinatesForNeighborhood(string neighborhoodName)
        {
            // Substitua pelo código real para chamar o serviço de geocodificação
            // Aqui, estou usando coordenadas de exemplo para fins ilustrativos.
            // Certifique-se de implementar essa chamada de maneira adequada.
            return new double[] { -26.8982, -49.0759 }; // Coordenadas de exemplo para Blumenau
        }
    }
}
