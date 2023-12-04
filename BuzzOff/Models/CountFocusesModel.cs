using Common.Interfaces;

namespace BuzzOff.Models
{
    public class CountFocusesModel
    {
        public List<ICountFocus> CountFocus { get; set; } = new List<ICountFocus>();    
        public int TotalFocus { get; set; }
        public List<ICoordinate> Coordenate { get; set; } = new List<ICoordinate>();
    }
}
