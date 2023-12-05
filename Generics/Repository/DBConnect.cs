using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    internal class DBConnect
    {


        public static string initialCatalog = "BuzzOffDB";
        static string dataSource = @"localhost\SQLEXPRESS";

        static string userID = "sa";
        static string password = "sa";


        public static string Connect()
        {
            if (Environment.MachineName == "x")
            {
                dataSource = @"localhost\SQLSERVER";
                password = "sa";
            } 

            else if (Environment.MachineName == "MACANEIRO")
            {
                dataSource = @"MACANEIRO\SQLEXPRESS";
                userID = "sa";
                password = "0505";
            }
            
            else if (Environment.MachineName == "TIAGO")
            {
                dataSource = @"TIAGO\SQLEXPRESS";
            }

            else if(Environment.MachineName == "VINILASO")
            {
                dataSource = @"VINILASO\SQLSERVER2022";
                password = "281705le";
            }


            return
                $"Data Source={dataSource};" +
                $"Initial Catalog={initialCatalog};" +
                $"User ID={userID};" +
                $"Password={password};TrustServerCertificate=true;";

        }
        public static bool TestConnect()
        {
            try
            {
                using (var conn = new SqlConnection(Connect()))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static string Create()
        {
            if (Environment.MachineName == "x")
            {
                dataSource = @"localhost\SQLSERVER";
                password = "sa";
            }

            return
                $"Data Source={dataSource};" +
                $"User ID={userID};" +
                $"Password={password};";
        }
    }

}
