using Common.Interfaces;
using Business.Generics;

namespace BuzzOff.Models
{
    public class CountFocusModel : ICountFocus
    {
        public CountFocusModel()
        {

        }
        public CountFocusModel(ICountFocus focus)
        {
            Counts = focus.Counts;
            Neighborhood = focus.Neighborhood;
        }

        public int Counts { get; set; }
        public string Neighborhood { get; set; }
    }

    public class AmountFocusModel : IAmountFocus
    {
        public int Value { get; set; }
    }
}
