using Common.Interfaces;

namespace BuzzOff.Models
{
    public class DenunciationsModel
    {
        public List<IDenunciation> Denunciations { get; set; } = new List<IDenunciation>();
    }
}
