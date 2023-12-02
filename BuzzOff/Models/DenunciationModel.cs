using Common.Interfaces;
using Common.Others;

namespace BuzzOff.Models
{
    public class DenunciationModel : IDenunciation
    {
        public DenunciationModel()
        {
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idInformer"></param>
        /// <param name="address"></param>
        /// <param name="comment"></param>
        /// <param name="focusType"></param>
        /// <param name="media"></param>
        /// <param name="stage"></param>
        /// <param name="isAnswered"></param>
        /// <param name="dataDenunciation"></param>
        public DenunciationModel(int id, int idInformer, IAddress address, string comment, MyEnuns.FocusType focusType, byte[] media, MyEnuns.DenunciationStage stage, bool isAnswered, DateTime dataDenunciation)
        {
            Id = id;
            IdInformer = idInformer;
            Address = address;
            Comment = comment;
            FocusType = focusType;
            Media = media;
            Stage = stage;
            IsAnswered = isAnswered;
            DataDenunciation = dataDenunciation;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }
        public IAddress Address { get; set; }
        public string Comment { get; set; }
        public MyEnuns.FocusType FocusType { get; set; }
        public byte[]? Media { get; set; }
        public MyEnuns.DenunciationStage Stage { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime DataDenunciation { get; set; }
    }
}
