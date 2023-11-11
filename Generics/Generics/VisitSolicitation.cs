using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    public class VisitSolicitation : IVisitSolicitation
    {
        public VisitSolicitation()
        {
            
        }
        public VisitSolicitation(int id, IVisit visit, ISolicitation solicitation)
        {

        }
        public int Id { get; set; }
        public IVisit Visit { get; set; }
        public ISolicitation Solicitation { get; set; }
    }
}
