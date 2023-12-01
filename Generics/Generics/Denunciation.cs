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
            IdInformer = 1;
            DataDenunciation = DateTime.Now;
            Stage = (DenunciationStage) 1;
            Address = new Address()
            {
                Id = 1,
            };
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
        public Denunciation(int id, int idInformer, IAddress address, DateTime dataDenunciation, byte[] media, bool isAnswered)
        {
            Id = id;
            IdInformer = idInformer;
            Address = address;
            DataDenunciation = dataDenunciation;
            this.media = media;
        }

        public Denunciation(int id, int idInformer, DateTime dataDenunciation, DenunciationStage stage, IAddress address)
        {
            Id = id;
            IdInformer = idInformer;
            DataDenunciation = dataDenunciation;            
            Stage = stage;
            Address = address;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[]? media { get; set; }
        public DenunciationStage Stage { get; set; }
        public IAddress Address { get; set; }
        public string Comment { get; set; }
        public FocusType FocusType { get; set; }
    }
} 
