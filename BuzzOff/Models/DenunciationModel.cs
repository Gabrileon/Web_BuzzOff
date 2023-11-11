using Business.Generics;
using Business.Repository.MidiaConverter;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class DenunciationModel: IDenunciation
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
        /// <param name="midia"></param>
        /// <param name="isAnswered"></param>
        public DenunciationModel(int idAddress, byte[] bytes)
        {  
            


            this.IdInformer = LoggedUser.loggedUser.Id;            
            this.IdAddress = idAddress;
            this.DataDenunciation = DateTime.Now;            
            this.midia = bytes;
            this.IsAnswered = false;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idInformer"></param>
        /// <param name="idAgent"></param>
        /// <param name="idAddress"></param>
        /// <param name="dataDenunciation"></param>
        /// <param name="dataVisit"></param>
        /// <param name="midia"></param>
        /// <param name="isAnswered"></param>
        public DenunciationModel(int id, int idInformer, int idAddress, DateTime dataDenunciation, byte[] bytes, bool isAnswered)
        {
            this.Id = id;
            this.IdInformer = idInformer;
            this.IdAddress = idAddress;
            this.DataDenunciation = dataDenunciation;            
            this.midia = bytes;
            this.IsAnswered = isAnswered;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }        
        public int IdAddress { get; set; }
        public DateTime DataDenunciation { get; set; }        
        public byte[] midia { get; set; }
        public bool IsAnswered { get; set; }
    }
}
