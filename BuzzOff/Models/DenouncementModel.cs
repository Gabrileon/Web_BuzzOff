using Common.Interfaces;
using Common.Others;
using System;

namespace BuzzOff.Models
{
    public class DenouncementModel : IDenouncement
    {
        public int Id { get; set; }
        public string cep { get; set; }
        public int number { get; set; }
        public string uf { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string comment { get; set; }
        //public byte[] media { get; set; }
        //public DateTime createdAt { get; set; }
        //public IUser user { get; set; }
        // Precisa de um status para controlar o andamento da denuncia, ex: Pendente, em andamento, resolvido
        // public MyEnuns.Denouncement status { get; set; } 

        //public DenouncementModel(int id, string cep, int number, string uf, string address, string city, string comment, byte[] media, DateTime createdAt, UserModel user)
        //{
        //    Id = id;
        //    this.cep = cep;
        //    this.number = number;
        //    this.uf = uf;
        //    this.address = address;
        //    this.city = city;
        //    this.comment = comment;
        //    this.media = media;
        //    this.createdAt = createdAt;
        //    this.user = user;
        //}
    }
}
