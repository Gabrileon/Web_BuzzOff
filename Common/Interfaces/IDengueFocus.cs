using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDengueFocus
    {
        public int Id { get; set; }
        public IAddress Address { get; set; }
        public IVisit Visit { get; set; }
        public MyEnuns.FocusType Type { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public bool IsEradicated { get; set; }
    }
}
