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
    public class CoordinateDAO
    {
        public static ICoordinate GetOne(string neighborhood)
        {
            ICoordinate model = null;

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ID, NEIGHBORHOOD, LATITUDE, LONGITUDE FROM COORDINATEFORMAP WHERE NEIGHBORHOOD = @Neighborhood;";
                cmd.Parameters.AddWithValue("@Neighborhood", neighborhood);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new Coordinate()
                        {
                            Id = (int)reader["ID"],
                            Neighborhood = (string)reader["NEIGHBORHOOD"],
                            Latitude = (decimal)reader["LATITUDE"],
                            Longitude = (decimal)reader["LONGITUDE"]
                        };
                    }
                }
            }

            return model;
        }

        public static List<ICoordinate> GetAll()
        {
            var list = new List<ICoordinate>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ID, NEIGHBORHOOD, LATITUDE, LONGITUDE FROM COORDINATEFORMAP";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new Coordinate()
                        {
                            Id = (int)reader["ID"],
                            Neighborhood = (string)reader["NEIGHBORHOOD"],
                            Latitude = (decimal)reader["LATITUDE"],
                            Longitude = (decimal)reader["LONGITUDE"]
                        };

                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
