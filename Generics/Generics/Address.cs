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
        /// 
        public Address() 
        { 
        }
        public Address(string neighborhood, string street, string number, string reference, string city)
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
        public Address(int id, string neighborhood, string street, string number, string reference, string city)
        {
            this.Id = id;
            this.Neighborhood = neighborhood;
            this.Street = street;
            this.Number = number;
            this.Reference = reference;
            this.City = city;
        }

        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }

        public string GetAddressString()
        {
            var sb = new StringBuilder();
            sb.Append(Street);
            sb.Append(", ");
            sb.Append(Number);
            sb.Append(" - ");
            sb.Append(Neighborhood);

            if (Reference != null)
            {
                sb.AppendLine(Reference);
            }

            sb.AppendLine(City);
            sb.Append("/SC");

            return sb.ToString();
        }
    }
}
