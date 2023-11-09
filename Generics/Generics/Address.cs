using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class Address: IAddress
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="neighborhood"></param>
        /// <param name="street"></param>
        /// <param name="number"></param>
        /// <param name="reference"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Address(string neighborhood, string street, string number, string reference, string latitude, string longitude)
        {
            this.neighborhood = neighborhood;
            this.street = street;
            this.number = number;
            this.reference = reference;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="neighborhood"></param>
        /// <param name="street"></param>
        /// <param name="number"></param>
        /// <param name="reference"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Address(int id, string neighborhood, string street, string number, string reference, string latitude, string longitude)
        {
            this.id = id;
            this.neighborhood = neighborhood;
            this.street = street;
            this.number = number;
            this.reference = reference;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public int id { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string reference { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
