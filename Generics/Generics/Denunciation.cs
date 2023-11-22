﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class Denunciation: IDenunciation
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
        public Denunciation(int idInformer, IAddress address, byte[] media)
        {
            IdInformer = idInformer;
            Address = address;
            DataDenunciation = DateTime.Now;
            this.media = media;
            IsAnswered = false;
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
            IsAnswered = isAnswered;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[] media { get; set; }
        public bool IsAnswered { get; set; }
        public bool IsFocus { get; set; }
        public IAddress Address { get; set; }
    }
} 
