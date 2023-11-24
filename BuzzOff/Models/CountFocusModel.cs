using Common.Interfaces;

namespace BuzzOff.Models
{
    public class CountFocusModel
    {
        public CountFocusModel()
        {

        }
        public CountFocusModel(int count, string neighborhood)
        {
            Count = count;
            Neighborhood = neighborhood;
        }

        public int Count { get; set; }
        public string Neighborhood { get; set; }
    }

    public class AmountFocusModel : IAmountFocus
    {
        public int Value { get; set; }
    }
}
