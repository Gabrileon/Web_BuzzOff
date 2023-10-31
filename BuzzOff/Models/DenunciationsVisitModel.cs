using Common.Interfaces;

namespace BuzzOff.Models
{
    public class DenunciationsVisitModel : IDenunciationsVisits
    {
        public DenunciationsVisitModel()
        {
            
        }
        public DenunciationsVisitModel(int Id, IDenunciation denunciation, IVisit visit)
        {
            
        }

        public int Id { get; set; }
        public IDenunciation Denunciation { get; set; }
        public IVisit Visit { get; set; }


    }
}
