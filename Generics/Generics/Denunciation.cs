using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Common.Others.MyEnuns;

namespace Business.Generics
{
    public class Denunciation : IDenunciation
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idInformer"></param>
        /// <param name="idAgent"></param>
        /// <param name="idAddress"></param>
        /// <param name="dataDenunciation"></param>
        /// <param name="dataVisit"></param>
        /// <param name="media"></param>
        /// <param name="isAnswered"></param>

        public Denunciation()
        {
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idInformer"></param>
        /// <param name="idAgent"></param>
        /// <param name="dataDenunciation"></param>
        /// <param name="dataVisit"></param>
        /// <param name="media"></param>
        /// <param name="isAnswered"></param>
        public Denunciation(int id, int idInformer, IAddress address, DateTime dataDenunciation, byte[] media, int isAnswered, FocusType focusType)
        {
            Id = id;
            IdInformer = idInformer;
            Address = address;
            DataDenunciation = dataDenunciation;
            Stage = (DenunciationStage)isAnswered;
            FocusType = focusType;
            this.Media = media;
        }
        public Denunciation(int id, int idInformer, IAddress address, DateTime dataDenunciation, byte[] media, FocusType focusType)
        {
            Id = id;
            IdInformer = idInformer;
            Address = address;
            DataDenunciation = dataDenunciation;
            FocusType = focusType;
            this.Media = media;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[] Media { get; set; }
        public string MediaName { get; set; }
        public DenunciationStage Stage { get; set; }
        public IAddress Address { get; set; }
        public FocusType FocusType { get; set; }
        public string Comment { get; set; }
    }
}
