using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ISolicitation
    {
        public int Id { get; set; }
        public int IdDenunciation { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public string Description { get; set; }
    }
}
