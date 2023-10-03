<<<<<<< HEAD:Generics/Generics/DengueFocus.cs
﻿using Business.Others;
=======
﻿using BuzzOff.Others;
>>>>>>> 8dd7fa1dd8064bffdd44b7cb1fb4a19f996cd511:Generics/DengueFocus.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:Generics/Generics/DengueFocus.cs
namespace Business.Generics
=======
namespace ClassLibrary
>>>>>>> 8dd7fa1dd8064bffdd44b7cb1fb4a19f996cd511:Generics/DengueFocus.cs
{
    internal class DengueFocus
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocus(int idAddress, int IdVisit, MyEnuns.FocusType type, bool isEradicated)
        {
            IdAddress = idAddress;
            this.IdVisit = IdVisit;
            Type = type;
            IsEradicated = false;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocus(int id, int idAddress, int IdVisit, MyEnuns.FocusType type, bool isEradicated)
        {
            Id = id;
            IdAddress = idAddress;
            this.IdVisit = IdVisit;
            Type = type;
            IsEradicated = isEradicated;
        }

        public int Id { get; set; }
        public int IdAddress { get; set; }
        public int IdVisit { get; set; }
        public MyEnuns.FocusType Type { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public bool IsEradicated { get; set; }
    }
}
