using static Common.Others.MyEnuns;

namespace Common.Interfaces
{
    public interface IDenunciation
    {
        public int Id { get; set; }
        public int IdInformer { get; set; }
        public IAddress Address { get; set; }
        public MyEnuns.FocusType FocusType { get; set; }
        public string Comment { get; set; }
        public MyEnuns.FocusType FocusType { get; set; }
        public byte[]? Media { get; set; }
        public MyEnuns.DenunciationStage Stage { get; set; }
        public DateTime DataDenunciation { get; set; }
    }
}