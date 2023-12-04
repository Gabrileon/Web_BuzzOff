using Common.Interfaces;
using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class DengueFocusModel:IDengueFocus
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idAddress"></param>
        /// <param name="type"></param>
        /// <param name="isEradicated"></param>
        public DengueFocusModel(IAddress idAddress, IVisit IdVisit, MyEnuns.FocusType type, bool isEradicated)
        {            
            this.Address = idAddress;
            this.Visit = IdVisit;
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
        public DengueFocusModel(int id, IAddress idAddress, IVisit IdVisit, MyEnuns.FocusType type, bool isEradicated)
        {
            this.Id = id;
            this.Address = idAddress;
            this.Visit = IdVisit;
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
