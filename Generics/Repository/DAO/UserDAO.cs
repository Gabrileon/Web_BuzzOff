using Business.Authentications.Cryptography;
using Business.Generics;
using Business.Repository;
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
    public class UserDAO
    {
        public static void Insert(IUser model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO Users (NAME, EMAIL, PASSWORD, CPF, ACCESSLEVEL)" +
                    $"VALUES (@NAME, @EMAIL, @PASSWORD, @CPF, @ACCESSLEVEL)";
                //$"VALUES ('{model.Name}', '{model.Email}', '{HashGenerator.GenerateHash(model.Password)}', '{model.CPF}', {model.AccessLevel})";
                cmd.Parameters.AddWithValue("@NAME", model.Name);
                cmd.Parameters.AddWithValue("@EMAIL", model.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(model.Password));
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@ACCESSLEVEL", 1);
                cmd.ExecuteNonQuery();
            }
        }


        public static void Update(IUser model)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "UPDATE Users SET " +
                    "NAME = @NAME," +
                    "EMAIL = @EMAIL," +
                    "PASSWORD = @PASSWORD," +
                    "CPF = @CPF, " +
                    "ACCESSLEVEL = @ACCESSLEVEL " +
                    "WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@NAME", model.Name);
                cmd.Parameters.AddWithValue("@EMAIL", model.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(model.Password));
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@ACCESSLEVEL", model.AccessLevel);

                cmd.ExecuteNonQuery();
            }
        }


        public static IUser GetOne(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IUser model = new User(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            (MyEnuns.Access)reader.GetInt32(4),
                            reader.GetInt32(0));
                        return model;
                    }
                }
                return null;
            }
        }

        public static List<IUser> GetAll()
        {
            var list = new List<IUser>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IUser model = new User(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            (MyEnuns.Access)reader.GetInt32(4),
                            reader.GetInt32(0));

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
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM USERS WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdatePassword(string password)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "UPDATE Users SET " +
                    "PASSWORD = @PASSWORD " +
                    "WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(password));
                cmd.Parameters.AddWithValue("@Id", LoggedUser.loggedUser.Id);


                cmd.ExecuteNonQuery();
            }
        }
    }
}