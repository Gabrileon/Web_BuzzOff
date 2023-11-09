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
        public int IdAddress { get; set; }
        public int IdVisit { get; set; }
        public MyEnuns.FocusType Type { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public bool IsEradicated { get; set; }
    }
}
