using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:Generics/Generics/Visit.cs
namespace Business.Generics
=======
namespace ClassLibrary
>>>>>>> 8dd7fa1dd8064bffdd44b7cb1fb4a19f996cd511:Generics/Visit.cs
{
    internal class Visit
    {
        public Visit(int id, int idAgent, int idDenunciation, DateTime dateVisit, string assement)
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
