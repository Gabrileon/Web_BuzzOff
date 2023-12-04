using Common.Interfaces;
using Common.Others;

namespace BuzzOff.Models
{
    public class DenunciationAddressModel
    {
        // Denunciation
        public DenunciationModel Denunciation { get; set; }

        // Adress
        public AddressModel Address { get; set; }

        public DenunciationAddressModel() { }

        public DenunciationAddressModel(IDenunciation denunciation) 
        {
            Denunciation = new DenunciationModel(denunciation);
            Address = new AddressModel(Denunciation.Address);
        }
    }
}
