﻿using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Others.MyEnuns;

namespace Common.Interfaces
{
    public interface IDenunciation
    {
        public int Id { get; set; }
        public int IdInformer { get; set; }
        public DateTime DataDenunciation { get; set; }
        public byte[] media { get; set; }
        public MyEnuns.DenunciationStage Stage { get; set; }
        public MyEnuns.FocusType FocusType { get; set; }
        public IAddress Address { get; set; }
        public string Comment { get; set; }
    }
}