using Common.Interfaces;

namespace BuzzOff.Models
{
    public class DenunciationVisitModel : IDenunciationVisit
    {
        public DenunciationVisitModel()
        {
            
        }
        public DenunciationVisitModel(int id, IDenunciation denunciation, IVisit visit)
        {
            Id = id;
            Denunciation = denunciation;
            Visit = visit;
        }

        public int Id { get; set; }
        public IDenunciation Denunciation { get; set; }
        public IVisit Visit { get; set; }
    }
}
