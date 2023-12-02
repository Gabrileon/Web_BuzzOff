using Common.Interfaces;
using Common.Others;

namespace BuzzOff.Models
{
    public class DenunciationAddressModel
    {
        // Denunciation
        public IDenunciation Denunciation { get; set; }

        // Adress
        public IAddress Address { get; set; }
    }
}
