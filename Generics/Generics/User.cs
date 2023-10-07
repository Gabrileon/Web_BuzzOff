using Common.Interfaces;
using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Generics
{
    internal class User : IUser
    {
        /// <summary>
        /// Insert.
        /// Sem nivel de acesso = usuário comum.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="cPF"></param>
        /// <param name="password"></param>
        /// <param name="accessLevel"></param>
        /// <param name="id"></param>
        public User(string name, string email, string cPF, string password, MyEnuns.Access accessLevel = MyEnuns.Access.Common)
        {
            Name = name;
            Email = email;
            Password = password;
            CPF = cPF;
            AccessLevel = accessLevel;
        }
        public User()
        {

        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="cPF"></param>
        /// <param name="accessLevel"></param>
        /// <param name="id"></param>
        public User(string name, string email, string cPF, MyEnuns.Access accessLevel, int id = 0)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = "*****";
            CPF = cPF;
            AccessLevel = accessLevel;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public MyEnuns.Access AccessLevel { get; set; }
    }
}
