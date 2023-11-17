using Common.Interfaces;
using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuzzOff.Models
{
    public class UserModel : IUser
    {
        /// <summary>
        /// Insert.
        /// Sem nivel de acesso = usuário comum.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="CPF"></param>
        /// <param name="password"></param>
        /// <param name="accessLevel"></param>
        /// <param name="id"></param>
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public MyEnuns.Access AccessLevel { get; set; }
    }
}
