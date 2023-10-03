using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Others
{
    public class MyExceptions
    {
        public static void InvalidLogin()
        {
            throw new Exception("CPF e/ou senha inválido(s).");
        }
        public static void InvalidCPF()
        {
            throw new Exception("CPF inválido.");
        }
    }
}
