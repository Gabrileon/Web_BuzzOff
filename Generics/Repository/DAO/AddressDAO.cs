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
    public class AddressDAO
    {

        public static int Insert(IAddress model)
        {
            int insert = 0;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText =
                    "INSERT INTO Addresses (Neighborhood, Street, Number, Reference, City) " +
                           "Output inserted.ID " +
                           "VALUES (@Neighborhood, @Street, @Number, @Reference, @City)";
                cmd.Parameters.AddWithValue("@Neighborhood", model.Neighborhood);
                cmd.Parameters.AddWithValue("@Street", model.Street);
                cmd.Parameters.AddWithValue("@Number", model.Number);
                cmd.Parameters.AddWithValue("@Reference", model.Reference);
                cmd.Parameters.AddWithValue("@City", model.City);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        insert = reader.GetInt32(0);
                    }
                }

                    return insert;
            }
        }

        public static void Update(IAddress model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText =
                    "UPDATE Addresses SET Neighborhood = @Neighborhood, " +
                    "Street = @Street, " +
                    "Number = @Number, " +
                    "Reference = @Reference, " +
                    "City = @City" + 
                    "WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Neighborhood", model.Neighborhood);
                cmd.Parameters.AddWithValue("@Street", model.Street);
                cmd.Parameters.AddWithValue("@Number", model.Number);
                cmd.Parameters.AddWithValue("@Reference", model.Reference);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public static IAddress GetOne(int id)
        {
            Address address = null;

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT ID, NEIGHBORHOOD, STREET, NUMBER, REFERENCE, CITY FROM ADDRESSES WHERE ID = @ID;";
                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        address = new Address()
                        {
                            Id = reader.GetInt32(0),
                            Neighborhood = reader.GetString(1),
                            Street = reader.GetString(2),
                            Number = reader.GetString(3),
                            Reference = reader.GetString(4),
                            City = reader.GetString(5)
                        };
                    }
                }
            }
            return address;
        }

        public static List<IAddress> GetAll()
        {
            var list = new List<IAddress>();

            IAddress model;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT Id, Neighborhood, Street, Number, Reference, City FROM Addresses";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model = new Address(
                             (int)reader["id"],
                             (string)reader["Neighborhood"],
                             (string)reader["Street"],
                             (string)reader["Number"],
                             (string)reader["Reference"],
                             (string)reader["City"]
                         );

                        list.Add(model);
                    }
                }

            }
            return list;
        }

        public static void Delete(int id)
        {
            var conn = new SqlConnection(DBConnect.Connect());
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM Addresses WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
        }
    }
}
