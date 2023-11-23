using Common.Interfaces;
using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    public class Denunciation : IDenunciation
    {
        private int v1;
        private int v2;
        private DateTime dateTime;
        private byte[] bytes;
        private bool v3;

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
            Stage = 0;
            Address.id = 1;
        }

        public Denunciation(int v1, int v2, IAddress address, DateTime dateTime, byte[] bytes, bool v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            Address = address;
            this.dateTime = dateTime;
            this.bytes = bytes;
            this.v3 = v3;
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
        /// <param name="media"></param>
        /// <param name="isAnswered"></param>

        public int Id { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[]? media { get; set; }
        public IAddress Address { get; set; }
        public MyEnuns.DenunciationStage Stage { get; set; }
    }
} 
