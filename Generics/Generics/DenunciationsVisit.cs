using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class DenunciationsVisit: IDenunciationVisit
    {
        public DenunciationsVisit()
        {

        }
        public DenunciationsVisit(int Id, IDenunciation denunciation, IVisit visit)
        {

        }

        public int Id { get; set; }
        public IDenunciation Denunciation { get; set; }
        public IVisit Visit { get; set; }

    }
}
