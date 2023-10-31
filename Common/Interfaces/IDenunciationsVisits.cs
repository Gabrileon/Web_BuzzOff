using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDenunciationsVisits
    {
        public int Id { get; set; }
        public IDenunciation Denunciation { get; set; }
        public IVisit Visit { get; set; }

    }
}
