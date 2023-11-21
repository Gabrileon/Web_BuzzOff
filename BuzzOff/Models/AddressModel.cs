﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class AddressModel: IAddress
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
        public AddressModel(string neighborhood, string street, string number, string reference, string city)
        {            
            this.neighborhood = neighborhood;
            this.street = street;
            this.number = number;
            this.reference = reference;
            this.city = city;
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
        public AddressModel(int id, string neighborhood, string street, string number, string reference, string city)
        {
            this.id = id;
            this.neighborhood = neighborhood;
            this.street = street;
            this.number = number;
            this.reference = reference;
            this.city = city;
        }

        public int id { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string reference { get; set; }
        public string city { get; set; }
    }
}
