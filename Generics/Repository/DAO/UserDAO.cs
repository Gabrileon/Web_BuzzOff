﻿using Business.Authentications.Cryptography;
using Business.Generics;
using Common.Interfaces;
using Common.Others;
using Microsoft.Data.SqlClient;


namespace Business.Repository.DAO
{
    public class UserDAO
    {
        public static int Insert(IUser model)
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
                cmd.Parameters.AddWithValue("@ACCESSLEVEL", 3);
                return cmd.ExecuteNonQuery();
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
                    "CPF = @CPF " +
                    "WHERE Id = @ID";

                cmd.Parameters.AddWithValue("@NAME", model.Name);
                cmd.Parameters.AddWithValue("@EMAIL", model.Email);
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@ID", model.Id);

                cmd.ExecuteNonQuery();
            }
        }
        public static IUser? GetOne(string Cpf, string Password)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users WHERE CPF = @CPF AND PASSWORD = @PASSWORD";
                cmd.Parameters.AddWithValue("@CPF", Cpf);
                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(Password));

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

        public static void UpdatePassword(string cpf, string name, string newPassword)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "UPDATE Users SET " +
                    "PASSWORD = @PASSWORD " +
                    "WHERE CPF = @CPF AND NAME = @NAME";

                cmd.Parameters.AddWithValue("@PASSWORD", HashGenerator.GenerateHash(newPassword));
                cmd.Parameters.AddWithValue("@CPF", cpf);
                cmd.Parameters.AddWithValue("@NAME", name);


                cmd.ExecuteNonQuery();
            }
        }
        public static IUser GetOneCPF(string cpf)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users WHERE CPF = @CPF";
                cmd.Parameters.AddWithValue("@CPF", cpf);
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
        public static List<IUser> GetAllCommons()
        {
            List<IUser> list = new();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, NAME, EMAIL, CPF, ACCESSLEVEL FROM Users WHERE ACCESSLEVEL = 3";
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
        public static void UpdateAccessLevel(int id, MyEnuns.Access accessLevel)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "UPDATE Users SET " +
                    "AccessLevel = @ACCESSLEVEL " +
                    "WHERE ID = @ID";
                var aaa = Convert.ToInt32(accessLevel);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ACCESSLEVEL", aaa);

                cmd.ExecuteNonQuery();
            }
        }
    }
}