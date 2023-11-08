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
        static string dataSource = @"BUE0001D017\SQLEXPRESS";

        static string userID = "sa";
        static string password = "Senac@2021";


        public static string Connect()
        {
            if (Environment.MachineName == "x")
            {
                dataSource = @"localhost\SQLSERVER";
                password = "sa";
            }

            return
                $"Data Source={dataSource};" +
                $"Initial Catalog={initialCatalog};" +
                $"User ID={userID};" +
                $"Password={password};TrustServerCertificate=true;";

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
