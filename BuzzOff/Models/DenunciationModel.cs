﻿using Business.Generics;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Common.Others.MyEnuns;

namespace BuzzOff.Models
{
    public class DenunciationModel : IDenunciation
    {
        ///// <summary>
        ///// Insert
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="idInformer"></param>
        ///// <param name="idAgent"></param>
        ///// <param name="idAddress"></param>
        ///// <param name="dataDenunciation"></param>
        ///// <param name="dataVisit"></param>
        ///// <param name="media"></param>
        ///// <param name="isAnswered"></param>
        //public DenunciationModel(int idAddress, byte[] media)
        //{            
        //    this.IdInformer = LoggedUser.loggedUser.Id;            
        //    this.IdAddress = idAddress;
        //    this.DataDenunciation = DateTime.Now;            
        //    this.media = media;
        //    this.IsAnswered = false;
        //}

        ///// <summary>
        ///// Get
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="idInformer"></param>
        ///// <param name="idAgent"></param>
        ///// <param name="idAddress"></param>
        ///// <param name="dataDenunciation"></param>
        ///// <param name="dataVisit"></param>
        ///// <param name="media"></param>
        ///// <param name="isAnswered"></param>
        //public DenunciationModel(int id, int idInformer, int idAddress, DateTime dataDenunciation, byte[] media, bool isAnswered)
        //{
        //    this.Id = id;
        //    this.IdInformer = idInformer;
        //    this.IdAddress = idAddress;
        //    this.DataDenunciation = dataDenunciation;            
        //    this.media = media;
        //    this.IsAnswered = isAnswered;
        //}
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
        public DenunciationModel(int id, int idInformer, AddressModel address, DateTime dataDenunciation, byte[] media, bool isAnswered, bool isFocus)
        {
            this.Id = id;
            this.IdInformer = idInformer;
            this.Address = address;
            this.DataDenunciation = dataDenunciation;            
            this.media = media;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }        
        public int IdAddress { get; set; }
        public DateTime DataDenunciation { get; set; }        
        public byte[] media { get; set; }
        public DenunciationStage Stage { get; set; }
        public IAddress Address { get; set; }
    }
}
