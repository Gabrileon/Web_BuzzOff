using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class VisitModel: IVisit
    {
        public VisitModel(int id, int idAgent, int idDenunciation, DateTime dateVisit, string assessment)
        {
            Id = id;
            IdAgent = idAgent;
            IdDenunciation = idDenunciation;
            DateVisit = dateVisit;
            Assessment = assessment;
        }
        public VisitModel()
        {

        }

        public int Id { get; set; }
        public int IdAgent { get; set; }
        public int IdDenunciation { get; set; }
        public DateTime DateVisit { get; set; }
        public string Assessment { get; set; }

    }
}
