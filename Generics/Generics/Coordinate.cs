using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class Coordinate: ICoordinate
    {
        public Coordinate()
        {

        }
        public Coordinate(int id, string neighborhood, decimal latitude, decimal longitude)
        {
            Id = id;
            Neighborhood = neighborhood;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
