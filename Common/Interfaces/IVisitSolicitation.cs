using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IVisitSolicitation
    {
        public int Id { get; set; }
        public IVisit Visit { get; set; }
        public ISolicitation Solicitation { get; set; }
    }
}
