using Common.Interfaces;
using Common.Others;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class DengueFocus: IDengueFocus
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocus(IAddress Address, IVisit Visit, MyEnuns.FocusType type, bool isEradicated)
        {
            this.Address = Address;
            this.Visit = Visit;
            this.Type = type;
            this.IsEradicated = false;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocus(int id, IAddress Address, IVisit Visit, MyEnuns.FocusType type, bool isEradicated)
        {
            this.Id = id;
            this.Address = Address;
            this.Visit = Visit;
            this.Type = type;
            this.IsEradicated = isEradicated;
        }

        public int Id { get; set; }
        public IAddress Address { get; set; }
        public IVisit Visit { get; set; }
        public MyEnuns.FocusType Type { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public bool IsEradicated { get; set; }
    }
}

