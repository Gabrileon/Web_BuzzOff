using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class CountFocus: ICountFocus
    {
        public CountFocus()
        {
            
        }
        public CountFocus(int count, string neighborhood)
        {
            Count = count;
            Neighborhood = neighborhood;
        }

        public int Count { get; set; }
        public string Neighborhood { get; set; }
    }

    public class AmountFocus: IAmountFocus
    {
        public int Value { get; set; }
    }
}
