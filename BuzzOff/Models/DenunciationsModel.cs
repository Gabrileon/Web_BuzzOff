﻿using Common.Interfaces;
using Common.Others;
using static Common.Others.MyEnuns;

namespace BuzzOff.Models
{
    public class DenunciationsModel
    {
        public List<IDenunciation> Denunciations { get; set; } = new List<IDenunciation>();

    }
}
