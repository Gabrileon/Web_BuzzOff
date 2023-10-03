using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IUser
    {
        public int Id { get;}
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string CPF { get;}
        public MyEnuns.Access AccessLevel { get; }
    }
}
