using Common.Interfaces;

namespace BuzzOff.Models
{
    public class CountFocusesModel
    {
        public List<ICountFocus> CountFocus { get; set; } = new List<ICountFocus>();

        public List<int> TotalFocus { get; set;} = new List<int>(); 
    }
}
