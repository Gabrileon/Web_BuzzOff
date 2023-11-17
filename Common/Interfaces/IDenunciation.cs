using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IDenunciation
    {
        public int Id { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[] media { get; set; }
        public bool IsAnswered { get; set; }
        public IAddress Address { get; set; }
    }
}
