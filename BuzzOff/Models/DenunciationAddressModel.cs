using Common.Interfaces;
using Common.Others;

namespace BuzzOff.Models
{
    public class DenunciationAddressModel
    {
        // Denunciation
        public int DenunciationId { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[]? media { get; set; }
        public IAddress Address { get; set; }
        public MyEnuns.DenunciationStage Stage { get; set; }

        // Adress
        public int AdressId { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }

        // Methods
        public DenunciationModel GetDenunciantionModel()
        {
            return new DenunciationModel()
            {
                Id = DenunciationId,
                IdInformer = IdInformer,
                DataDenunciation = DataDenunciation,
                Address = Address,
                Stage = Stage
            };
        }

        public AddressModel GetAddressModel()
        {
            return new AddressModel()
            {
                Id = AdressId,
                Neighborhood = Neighborhood,
                Street = Street,
                Number = Number,
                Reference = Reference,
                City = City
            };
        }
    }
}
