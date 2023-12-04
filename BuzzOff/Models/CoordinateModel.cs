using Common.Interfaces;

namespace BuzzOff.Models
{
    public class CoordinateModel: ICoordinate
    {
        public CoordinateModel()
        {
            
        }
        public CoordinateModel(int id, string neighborhood, decimal latitude, decimal longitude)
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
