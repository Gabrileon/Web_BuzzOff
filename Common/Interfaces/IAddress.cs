using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IAddress
    {
        public int id { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string reference { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
