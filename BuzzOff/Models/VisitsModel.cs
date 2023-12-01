using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class VisitsModel
    {
        public List<IVisit> Visits { get; set; } = new List<IVisit>();

    }
}
