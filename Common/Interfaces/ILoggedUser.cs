using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ILoggedUser
    {
        //public string Name { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public bool rememberMe { get; set; }
    }
}
