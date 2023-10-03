using Business.Repository;
using Common.Others;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentications
{
    public class CpfValidadtions
    {   
        public static bool verifyLogin(string name, string password)
        {
            return ((name.ToLower() == "adm") && (password == "123"));
        }

        public static string ClearCPF(string CPF)
        {
            CPF = new string(CPF.Where(char.IsDigit).ToArray());
            var ClearCPF = "";

            foreach (var cpf in CPF)
            {
                ClearCPF += cpf;
            }
            return ClearCPF;
        }

        public static bool IsValidCPF(string _CPF)
        {
            _CPF = new string(_CPF.Where(char.IsDigit).ToArray());

            if (_CPF.Length != 11)
            {
                MyExceptions.InvalidCPF();
                return false;
            }

            if (_CPF.Distinct().Count() == 1)
            {
                MyExceptions.InvalidCPF();
                return false;
            }

            int cheker = CalculateChecker(_CPF, 10, 9);

            if ((int.Parse(_CPF[9].ToString()) != cheker))
            {
                MyExceptions.InvalidCPF();
            }

            cheker = CalculateChecker(_CPF, 11, 10);

            if ((int.Parse(_CPF[10].ToString()) != cheker))
            {
                MyExceptions.InvalidCPF();
            }

            return true;
        }
        private static int CalculateChecker(string _CPF, int start, int index )
        {
            int sum = 0;
            for (var i = 0; i < index; i++)
            {
                if (_CPF[i] != '0')
                {
                    var mult = int.Parse(_CPF[i].ToString());
                    sum += mult * (start- i);
                }
            }
            var verifyngDigit = sum % 11;
            var result = verifyngDigit < 2 ? 0 : 11 - verifyngDigit;

            return result;
        }

        public bool IsValidID(int id, string table)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                int maxID = -1;
                int minID = -1;

                var cmdMax = conn.CreateCommand();
                cmdMax.CommandText = $"SELEC MAX(ID) FROM {table.ToUpper()}";
                maxID = cmdMax.ExecuteReader().GetInt32(0);

                var cmdMin = conn.CreateCommand();
                cmdMin.CommandText = $"SELEC MIN(ID) FROM {table.ToUpper()}";
                maxID = cmdMin.ExecuteReader().GetInt32(0);

                return ((maxID <= id) && (minID >= id));
            }
        }
        public static bool verifyNumber(string s)
        {
            return int.TryParse(s, out _);

            //Apagar quando desenvolver a interface Web
        }
    }
}
