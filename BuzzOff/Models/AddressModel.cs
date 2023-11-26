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

        public string GetAddressString()
        {
            var sb = new StringBuilder();
            sb.Append(Street);
            sb.Append(", ");
            sb.Append(Number);
            sb.Append(" - ");
            sb.Append(Neighborhood);

            if(Reference != null)
            {
                sb.AppendLine(Reference);
            }

            sb.AppendLine(City);
            sb.Append("/SC");

            return sb.ToString();
            
        }

        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }
    }
}
