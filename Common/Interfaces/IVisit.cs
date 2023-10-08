using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IVisit
    {
        public int Id { get; set; }
        public int IdAgent { get; set; }
        public int IdDenunciation { get; set; }
        public DateTime DateVisit { get; set; }
        public string Assement { get; set; }
    }
}
