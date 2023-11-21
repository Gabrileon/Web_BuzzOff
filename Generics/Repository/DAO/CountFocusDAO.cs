using Business.Generics;
using Common.Interfaces;
using Common.Others;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DAO
{
    internal class CountFocusDAO
    {
        /// <summary>
        /// true para focos erradicados.
        /// false para focos não erradicados
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static List<ICountFocus> CountByErraticatedAndNeighborhood(bool b)
        {
            List<ICountFocus> list = new List<ICountFocus>();
            ICountFocus model = new CountFocus();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"select COUNT(dbo.Addresses.Neighborhood) as Quantidade, Addresses.Neighborhood from Addresses \r\nleft join dbo.DengueFocus on IDAddress = dbo.Addresses.ID " +
                    $"where dbo.DengueFocus.IsEradicated = {b}" +
                    $"group by Addresses.Neighborhood";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model = new CountFocus(
                           (int)reader["Amount"],
                           (string)reader["Neighborhood"]
                       );

                        list.Add(model);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// true para focos erradicados.
        /// false para focos não erradicados
        /// </summary>
        /// <returns></returns>
        public static int AmountByErradicated(bool b)
        {
            var result = 0;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT COUNT(dbo.DengueFocus.IsEradicated) as result from DengueFocus where IsEradicated = {b}";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader["result"]);
                    }
                }
                return result;
            }
        }

        public static int AmountOfFocus()
        {
            var result = 0;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT COUNT(dbo.DengueFocus.IsEradicated) as result from DengueFocus";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader["result"]);
                    }
                }
                return result;
            }
        }

        
    }
}

