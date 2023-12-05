using Business.Generics;
using Business.Repository.DAO;
using Common.Interfaces;
using Common.Others;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Common.Others.MyEnuns;

namespace Business.Repository
{
    public class DenunciationDAO
    {
        public static int Insert(IDenunciation model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"INSERT INTO Denunciations (IdInformer, IdAddress, DataDenunciation{(model.Media != null ? ", Media, MediaName" : string.Empty)}, Comment, Stage, FocusType) " +
                                  $"VALUES (@IdInformer, @IdAddress, @DataDenunciation{(model.Media != null ? ", @Media, @MediaName" : string.Empty)}, @Comment, @Stage, @FocusType)";
                cmd.Parameters.AddWithValue("@IdInformer", model.IdInformer);
                cmd.Parameters.AddWithValue("@IdAddress", model.Address.Id);
                cmd.Parameters.AddWithValue("@DataDenunciation", model.DataDenunciation);
                cmd.Parameters.AddWithValue("@FocusType", (int)model.FocusType);
                cmd.Parameters.AddWithValue("@Stage", model.Stage);
                cmd.Parameters.AddWithValue("@Comment", model.Comment);

                if (model.Media != null)
                {
                    cmd.Parameters.AddWithValue("@Media", model.Media);
                    cmd.Parameters.AddWithValue("@MediaName", model.MediaName);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        public static void Update(IDenunciation model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Denunciations SET " +
                    "IdInformer = @IdInformer, " +
                    "IdAddress = @IdAddress," +
                    "DataDenunciation = @DataDenunciation " +
                    $"{(model.Media != null ? ", Media = @Media, MediaName = @MediaName" : string.Empty)}," +
                    "Stage = @Stage, " +
                    "Comment = @Comment" +
                    " WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@IdInformer", model.IdInformer);
                cmd.Parameters.AddWithValue("@IdAddress", model.Address.Id);
                cmd.Parameters.AddWithValue("@DataDenunciation", model.DataDenunciation);
                cmd.Parameters.AddWithValue("@FocusType", (int)model.FocusType);
                cmd.Parameters.AddWithValue("@Stage", (int)model.Stage);
                cmd.Parameters.AddWithValue("@Comment", model.Comment);
                if (model.Media != null)
                {
                    cmd.Parameters.AddWithValue("@Media", model.Media);
                    cmd.Parameters.AddWithValue("@MediaName", model.MediaName);
                }
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public static IDenunciation GetOne(int id)
        {
            IDenunciation model = null;
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, MediaName, Comment, Stage, FocusType FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new Denunciation()
                        {
                            Id = (int)reader["Id"],
                            IdInformer = (int)reader["IdInformer"],
                            Address = AddressDAO.GetOne((int)reader["IdAddress"]),
                            DataDenunciation = (DateTime)reader["DataDenunciation"],
                            Media = reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            MediaName = reader["MediaName"] != DBNull.Value ? (string)reader["MediaName"] : null,
                            Stage = (DenunciationStage)reader["Stage"],
                            FocusType = (FocusType)reader["FocusType"],
                            Comment = reader["Comment"] != DBNull.Value ? (string)reader["Comment"] : null
                        };
                    }
                }
            }
            return model;
        }

        public static List<IDenunciation> GetByInformerId(int id)
        {
            var list = new List<IDenunciation>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, MediaName, Comment, Stage, FocusType FROM Denunciations WHERE IdInformer = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation()
                        {
                            Id = (int)reader["Id"],
                            IdInformer = (int)reader["IdInformer"],
                            Address = AddressDAO.GetOne((int)reader["IdAddress"]),
                            DataDenunciation = (DateTime)reader["DataDenunciation"],
                            Media = reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            MediaName = reader["MediaName"] != DBNull.Value ? (string)reader["MediaName"] : null,
                            Stage = (DenunciationStage)reader["Stage"],
                            FocusType = (FocusType)reader["FocusType"],
                            Comment = reader["Comment"] != DBNull.Value ? (string)reader["Comment"] : null
                        };

                        list.Add(model);
                    }
                }
            }
            return list;
        }
        public static List<IDenunciation> GetByInformerIdAndStage(int id, bool b)
        {
            var list = new List<IDenunciation>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, Comment, Stage, FocusType FROM Denunciations WHERE IdInformer = @Id and IsAnswered = @B";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@B", b);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation()
                        {
                            Id = (int)reader["Id"],
                            IdInformer = (int)reader["IdInformer"],
                            Address = AddressDAO.GetOne((int)reader["IdAddress"]),
                            DataDenunciation = (DateTime)reader["DataDenunciation"],
                            Media = reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            MediaName = reader["MediaName"] != DBNull.Value ? (string)reader["MediaName"] : null,
                            Stage = (DenunciationStage)reader["Stage"],
                            FocusType = (FocusType)reader["FocusType"],
                            Comment = reader["Comment"] != DBNull.Value ? (string)reader["Comment"] : null
                        };
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public static List<IDenunciation> GetAll()
        {
            var list = new List<IDenunciation>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, Comment, Stage, FocusType FROM Denunciations";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation()
                        {
                            Id = (int)reader["Id"],
                            IdInformer = (int)reader["IdInformer"],
                            Address = AddressDAO.GetOne((int)reader["IdAddress"]),
                            DataDenunciation = (DateTime)reader["DataDenunciation"],
                            Media = reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            MediaName = reader["MediaName"] != DBNull.Value ? (string)reader["MediaName"] : null,
                            Stage = (DenunciationStage)reader["Stage"],
                            FocusType = (FocusType)reader["FocusType"],
                            Comment = reader["Comment"] != DBNull.Value ? (string)reader["Comment"] : null
                        };
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        public static void Delete(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
        public static List<IDenunciation> GetAllPendent()
        {
            var list = new List<IDenunciation>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, DataDenunciation, Media, MediaName, Comment, Stage, FocusType FROM Denunciations WHERE Stage = 1";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation()
                        {
                            Id = (int)reader["Id"],
                            IdInformer = (int)reader["IdInformer"],
                            Address = AddressDAO.GetOne((int)reader["IdAddress"]),
                            DataDenunciation = (DateTime)reader["DataDenunciation"],
                            Media = reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            MediaName = reader["MediaName"] != DBNull.Value ? (string)reader["MediaName"] : null,
                            Stage = (DenunciationStage)reader["Stage"],
                            FocusType = (FocusType)reader["FocusType"],
                            Comment = reader["Comment"] != DBNull.Value ? (string)reader["Comment"] : null
                        };
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        /*
        public (List<IDenunciation>, List<IDenunciation>) JoinWithAddress()
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var sql = @"SELECT d.*, a.*
                    FROM Denunciations d
                    INNER JOIN Addresses a ON d.IDAddress = a.ID";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    var denunciations = new List<IDenunciation>();
                    var addresses = new List<IAddress>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var address = new Address(
                                (int)reader["IDAddress"],
                                (string)reader["Neighborhood"],
                                (string)reader["Street"],
                                (string)reader["Number"],
                                (string)reader["Reference"],
                                (string)reader["Latitude"],
                                (string)reader["Longitude"]
                            );

                            addresses.Add(address);

                            var denunciation = new Denunciation(

                                (int)reader["ID"],
                                (int)reader["IDInformer"],
                                (int)reader["IDAddress"],
                                (DateTime)reader["DataDenunciation"],
                                (byte[])reader["Media"],
                                (bool)reader["IsAnswered"]
                            );

                            denunciations.Add(denunciation);
                        }
                    }

                    return (denunciations, addresses);
                }
            }
        }
        */

        //public void Delete2()
        //{
        //    using (var conn = new SqlConnection(DBConnect.Connect()))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "DELETE FROM Denunciations WHERE IDInformer = @IDInformer";
        //        cmd.Parameters.AddWithValue("@IDInformer", LoggedUser.loggedUser.Id);

        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
