using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class VisitModel
    {
        public VisitModel(int id, int idAgent, int idDenunciation, DateTime dateVisit, string assement)
        {
            Id = id;
            IdAgent = idAgent;
            IdDenunciation = idDenunciation;
            DateVisit = dateVisit;
            Assement = assement;
        }

        public int Id { get; set; }
        public int IdAgent { get; set; }
        public int IdDenunciation { get; set; }
        public DateTime DateVisit { get; set; }
        public string Assement { get; set; }

    }
}
