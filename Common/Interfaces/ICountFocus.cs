using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICountFocus
    {
        public int Count { get; set;}
        public string Neighborhood { get; set;}
    }

    public interface IAmountFocus
    {
       public int Value { get; set;}
    }
}
