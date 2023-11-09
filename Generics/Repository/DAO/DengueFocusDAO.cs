using Business.Generics;
using Common.Interfaces;
using Common.Others;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.DAO
{
    internal class DengueFocusDAO
    {
        public void Insert(IDengueFocus model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DengueFocus (IdAddress, IdVisit, Type, IsEradicated) " +
                                  "VALUES (@IdAddress, @IdVisit, @Type, @IsEradicated)";

                cmd.Parameters.AddWithValue("@IdVisit", model.IdVisit);
                cmd.Parameters.AddWithValue("@IdAddress", model.IdAddress);
                cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                cmd.Parameters.AddWithValue("@IsEradicated", 0);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(IDengueFocus model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE DengueFocus SET " +
                    "IdAddress = @IdAddress, " +
                    "IdVisit =  @Idvisit" +
                    "Type = @Type, " +
                    "IsEradicated = @IsEradicated " +
                    "WHERE Id = @Id";


                cmd.Parameters.AddWithValue("@IdAddress", model.IdAddress);
                cmd.Parameters.AddWithValue("@IdVisit", model.IdVisit);
                cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                cmd.Parameters.AddWithValue("@IsEradicated", (bool)model.IsEradicated);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public IDengueFocus GetOne(int id)
        {
            IDengueFocus model = null;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdAddress, IdVisit, IdVisit, Type, IsEradicated  FROM DengueFocus WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new DengueFocus(
                            (int)reader["Id"],
                            (int)reader["IdAddress"],
                            (int)reader["IdVisit"],
                            (MyEnuns.FocusType)reader["Type"],
                            (bool)reader["IsEradicated"]
                        );
                    }
                }
            }
            return model;
        }

        public List<IDengueFocus> GetAll()
        {
            var list = new List<IDengueFocus>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdAddress, IdVisit, IdVisit, Type, IsEradicated  FROM DengueFocus";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDengueFocus model = new DengueFocus(
                            (int)reader["Id"],
                            (int)reader["IdAddress"],
                            (int)reader["IdVisit"],
                            (MyEnuns.FocusType)reader["Type"],
                            (bool)reader["IsEradicated"]
                        );

                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM DengueFocus WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
