using Common.Interfaces;

namespace BuzzOff.Models
{
    public class VisitSolicitationsModel
    {
        public List<IVisitSolicitation> visitSolicitations { get; set; } = new List<IVisitSolicitation>();
    }
}
