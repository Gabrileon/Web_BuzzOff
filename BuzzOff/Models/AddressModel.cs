using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff.Models
{
    public class AddressModel: IAddress
    {
        public AddressModel()
        {

        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="neighborhood"></param>
        /// <param name="street"></param>
        /// <param name="number"></param>
        /// <param name="reference"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// 

        public AddressModel(string neighborhood, string street, string number, string reference, string city)
        {            
            this.Neighborhood = neighborhood;
            this.Street = street;
            this.Number = number;
            this.Reference = reference;
            this.City = city;
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
            this.Id = id;
            this.Neighborhood = neighborhood;
            this.Street = street;
            this.Number = number;
            this.Reference = reference;
            this.City = city;
        }

        public AddressModel(IAddress address)
        {
            Id = address.Id;
            Neighborhood = address.Neighborhood;
            Street = address.Street;
            Number = address.Number;
            Reference = address.Reference;
            City = address.City;
        }

        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }
    }
}
