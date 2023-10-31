using Common.Interfaces;

namespace BuzzOff.Models
{
    public class VisitSolicitationsModel : IVisitSolicitations
    {

        public VisitSolicitationsModel(int id, IVisit visit, ISolicitation solicitation)
        {
            
        }
        public int Id { get; set; }
        public IVisit Visit { get; set; }
        public ISolicitation Solicitation { get; set; }
    }
}
