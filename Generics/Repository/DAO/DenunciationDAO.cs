using Business.Generics;
using Business.Repository.DAO;
using Common.Interfaces;
using Microsoft.Data.SqlClient;
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
                cmd.CommandText = "INSERT INTO Denunciations (IdInformer, IdAddress, Comment, FocusType, Media, Stage, DataDenunciation, IsAnswered) " +
                                  "VALUES (@IdInformer, @IdAddress, @Comment, @FocusType, @Media, @Stage, @DataDenunciation, @IsAnswered)";
                cmd.Parameters.AddWithValue("@IdInformer", model.IdInformer);
                cmd.Parameters.AddWithValue("@IdAddress", model.Address.Id);
                cmd.Parameters.AddWithValue("@Comment", model.Comment);
                cmd.Parameters.AddWithValue("@FocusType", model.FocusType);
                cmd.Parameters.AddWithValue("@Media", model.Media);
                cmd.Parameters.AddWithValue("@Stage", model.Stage);
                cmd.Parameters.AddWithValue("@DataDenunciation", model.DataDenunciation);
                cmd.Parameters.AddWithValue("@IsAnswered", 1);

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
                    "DataDenunciation = @DataDenunciation, " +
                    "Media = @Media, " +
                    "IsAnswered = @IsAnswered" +
                    " WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@IdInformer", model.IdInformer);
                cmd.Parameters.AddWithValue("@IdAddress", model.Address.Id);
                cmd.Parameters.AddWithValue("@DataDenunciation", model.DataDenunciation);
                cmd.Parameters.AddWithValue("@Media", model.Media);
                cmd.Parameters.AddWithValue("@IsAnswered", model.Stage);
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
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, Comment, FocusType, Media, Stage, IsAnswered, DataDenunciation FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new Denunciation(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],
                            AddressDAO.GetOne((int)reader["IdAddress"]),
                            (string)reader["Comment"],
                            (FocusType)reader["FocusType"],
                            reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            (DenunciationStage)reader["Stage"],
                            (bool)reader["IsAnswered"],
                            (DateTime)reader["DataDenunciation"]
                        );
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
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, Comment, FocusType, Media, Stage, IsAnswered, DataDenunciation FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],
                            AddressDAO.GetOne((int)reader["IdAddress"]),
                            (string)reader["Comment"],
                            (FocusType)reader["FocusType"],
                            reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            (DenunciationStage)reader["Stage"],
                            (bool)reader["IsAnswered"],
                            (DateTime)reader["DataDenunciation"]
                        );
                        list.Add(model);
                    }
                }
            }
            return list;
        }
        public static List<IDenunciation> GetByInformerIdAndIsAnswered(int id, bool b)
        {
            var list = new List<IDenunciation>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, Comment, FocusType, Media, Stage, IsAnswered, DataDenunciation FROM Denunciations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@B", b);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation(
                            (int)reader["Id"],
                            (int)reader["IdInformer"],
                            AddressDAO.GetOne((int)reader["IdAddress"]),
                            (string)reader["Comment"],
                            (FocusType)reader["FocusType"],
                            reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            (DenunciationStage)reader["Stage"],
                            (bool)reader["IsAnswered"],
                            (DateTime)reader["DataDenunciation"]
                        );
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
                cmd.CommandText = "SELECT Id, IdInformer, IdAddress, Comment, FocusType, Media, Stage, IsAnswered, DataDenunciation FROM Denunciations WHERE Id = @Id";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDenunciation model = new Denunciation()
                        {
                            Id = (int)reader["Id"],
                            IdInformer = (int)reader["IdInformer"],
                            Address = AddressDAO.GetOne((int)reader["IdAddress"]),
                            Comment = (string)reader["Comment"],
                            FocusType = (FocusType)reader["FocusType"],
                            Media = reader["Media"] != DBNull.Value ? (byte[])reader["Media"] : null,
                            Stage = (DenunciationStage)reader["Stage"],
                            IsAnswered = (bool)reader["IsAnswered"],
                            DataDenunciation = (DateTime)reader["DataDenunciation"]
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
