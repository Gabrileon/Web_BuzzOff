using Common.Interfaces;

namespace BuzzOff.Models
{
    public class VisitSolicitationModel : IVisitSolicitation
    {
        public VisitSolicitationModel()
        {
            
        }

        public VisitSolicitationModel(int id, IVisit visit, ISolicitation solicitation)
        {
            
        }
        public int Id { get; set; }
        public IVisit Visit { get; set; }
        public ISolicitation Solicitation { get; set; }
    }
}
