using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IConclusionVisit
    {
        public int Id { get; set; }
        public int IdDenunciation { get; set; }
        public byte[] Report { get; set; }
    }
}
