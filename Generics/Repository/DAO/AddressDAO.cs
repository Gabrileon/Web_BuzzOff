﻿using Business.Generics;
using Common.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DAO
{
    internal class AddressDAO
    {

        public int Insert(IAddress model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText =
                    "INSERT INTO Addresses (Neighborhood, Street, Number, Reference, Latitude, Longitude) " +
                           "VALUES (@Neighborhood, @Street, @Number, @Reference, @Latitude, @Longitude)";
                cmd.Parameters.AddWithValue("@Neighborhood", model.neighborhood);
                cmd.Parameters.AddWithValue("@Street", model.street);
                cmd.Parameters.AddWithValue("@Number", model.number);
                cmd.Parameters.AddWithValue("@Reference", model.reference);
                cmd.Parameters.AddWithValue("@Latitude", model.latitude);
                cmd.Parameters.AddWithValue("@Longitude", model.longitude);

                return cmd.ExecuteNonQuery();
            }
        }

        public void Update(IAddress model)
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
                    "Latitude = @Latitude, " +
                    "Longitude = @Longitude " +
                    "WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Neighborhood", model.neighborhood);
                cmd.Parameters.AddWithValue("@Street", model.street);
                cmd.Parameters.AddWithValue("@Number", model.number);
                cmd.Parameters.AddWithValue("@Reference", model.reference);
                cmd.Parameters.AddWithValue("@Latitude", model.latitude);
                cmd.Parameters.AddWithValue("@Longitude", model.longitude);
                cmd.Parameters.AddWithValue("@Id", model.id);

                cmd.ExecuteNonQuery();
            }
        }

        public IAddress GetOne(int id)
        {
            IAddress address;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT Id, Neighborhood, Street, Number, Reference, Latitude, Longitude FROM Addresses WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        address = new Address(
                            (int)reader["Id"],
                            (string)reader["Neighborhood"],
                            (string)reader["Street"],
                            (string)reader["Number"],
                            (string)reader["Reference"],
                            (string)reader["Latitude"],
                            (string)reader["Longitude"]
                          );

                        return address;

                    }
                }

            }
            return null;

        }

        public List<IAddress> GetAll()
        {
            var list = new List<IAddress>();

            IAddress model;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT Id, Neighborhood, Street, Number, Reference, Latitude, Longitude FROM Addresses";
                ;

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
                             (string)reader["Latitude"],
                             (string)reader["Longitude"]
                         );

                        list.Add(model);
                    }
                }

            }
            return list;
        }

        public void Delete(int id)
        {
            var conn = new SqlConnection(DBConnect.Connect());
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM Addresses WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
        }
    }
}
