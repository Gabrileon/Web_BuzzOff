using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICoordinate
    {
        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
