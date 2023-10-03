using Common.Interfaces;
using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Generics
{
    public class LoggedUser
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string CPF { get; private set; }
        public MyEnuns.Access AccessLevel { get; private set; }

        private bool authenticated = false;
        public bool Authenticated { get { return authenticated; } }

        public static LoggedUser loggedUser { get; private set; }


    }
}
