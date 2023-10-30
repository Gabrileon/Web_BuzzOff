using Business.Generics;
using Common.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DAO
{
    internal class VisitDAO
    {
        public static List<IVisit> GetAll()
        {
            var list = new List<IVisit>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Visit";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //IVisit model = new Visit(
                        //    reader.GetString(1),
                        //    reader.GetString(2),
                        //    reader.GetString(3),
                        //    (MyEnuns.Access)reader.GetInt32(4),
                        //    reader.GetInt32(0));

                        //list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
