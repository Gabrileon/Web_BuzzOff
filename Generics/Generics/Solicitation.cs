using ClassLibrary.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    internal class Solicitation
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idDenunciation"></param>
        /// <param name="priority"></param>
        /// <param name="description"></param>
        public Solicitation(int idDenunciation, MyEnuns.Priority priority, string description)
        {
            IdDenunciation = idDenunciation;
            Priority = priority;
            Description = description;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idDenunciation"></param>
        /// <param name="priority"></param>
        /// <param name="description"></param>
        public Solicitation(int id, int idDenunciation, MyEnuns.Priority priority, string description)
        {
            Id = id;
            IdDenunciation = idDenunciation;
            Priority = priority;
            Description = description;
        }

        public int Id { get; set; }
        public int IdDenunciation { get; set; }
        public MyEnuns.Priority Priority { get; set; }
        public string Description { get; set; }
    }
}
