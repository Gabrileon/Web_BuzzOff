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
        public VisitModel()
        {

        }
        public VisitModel(int id, int idAgent, IDenunciation denunciation, DateTime dateVisit, string assessment)
        {
            Id = id;
            IdAgent = idAgent;
            Denunciation = denunciation;
            DateVisit = dateVisit;
            Assessment = assessment;
        }      

        public int Id { get; set; }
        public int IdAgent { get; set; }
        public IDenunciation Denunciation { get; set; }
        public DateTime DateVisit { get; set; }
        public string Assessment { get; set; }
    }
}
