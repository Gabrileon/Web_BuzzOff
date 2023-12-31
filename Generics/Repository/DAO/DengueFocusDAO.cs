﻿using Business.Generics;
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
                cmd.CommandText = "INSERT INTO DengueFocus (IdAddress, IdVisit, Type, IsEradicated, Priority) " +
                                  "VALUES (@IdAddress, @IdVisit, @Type, @IsEradicated, @Priority)";

                cmd.Parameters.AddWithValue("@IdVisit", model.Visit.Id);
                cmd.Parameters.AddWithValue("@IdAddress", model.Address.Id);
                cmd.Parameters.AddWithValue("@IsEradicated", model.IsEradicated);
                cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                cmd.Parameters.AddWithValue("@Priority", (int)model.Priority);

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
                    "Priority = @Priority " +
                    "WHERE Id = @Id";


                cmd.Parameters.AddWithValue("@IdAddress", model.Address.Id);
                cmd.Parameters.AddWithValue("@IdVisit", model.Visit.Id);
                cmd.Parameters.AddWithValue("@Type", (int)model.Type);
                cmd.Parameters.AddWithValue("@IsEradicated", (bool)model.IsEradicated);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Priority", (int)model.Priority);

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
                cmd.CommandText = "SELECT Id,IdAddress, IdVisit, Type, IsEradicated, Priority  FROM DengueFocus WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new DengueFocus(
                            (int)reader["Id"],
                            (int)reader["IdAddress"],
                            (int)reader["IdVisit"],
                            (bool)reader["IsEradicated"],
                            (MyEnuns.FocusType)reader["Type"],
                            (MyEnuns.Priority)reader["Priority"]
                        );
                    }
                }
            }
            return model;
        }

        public List<IDengueFocus> GetByNeighborhood(string neighborhood)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                //IDADDRESSS, IDVISIT

                var sql = @$"SELECT dbo.DengueFocus.ID, TYPE, PRIORITY, ISERADICATED, 
                            dbo.Addresses.ID, CITY, NEIGHBORHOOD, STREET, NUMBER, REFERENCE, 
                            dbo.Visits.ID, IDAGENT, IDDENUNCIATION, DATAVISIT, ASSESSMENT 
                            FROM DENGUEFOCUS WHERE Neighborhood = {neighborhood}
                            INNER JOIN ADDRESSES ON IDADDRESS = dbo.Addresses.ID
                            INNER JOIN VISITS ON IDVISIT = dbo.Visits.ID";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    var list = new List<IDengueFocus>();
                    IDengueFocus focus = null;



                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            focus.Id = (int)reader["dbo.DengueFocus.ID"];
                            focus.Type = (MyEnuns.FocusType)reader["TYPE"];
                            focus.Priority = (MyEnuns.Priority)reader["PRIORITY"];
                            focus.IsEradicated = (bool)reader["ISERADICATED"];

                            focus.Address = new Address(
                                (int)reader["dbo.Addresses.ID"],
                                (string)reader["Neighborhood"],
                                (string)reader["Street"],
                                (string)reader["Number"],
                                (string)reader["Reference"],
                                (string)reader["City"]
                            );

                            focus.Visit = new Visit(

                                (int)reader["dbo.Visits.ID"],
                                (int)reader["IDAgent"],
                                DenunciationDAO.GetOne((int)reader["IDDenunciation"]),
                                (DateTime)reader["DateVisit"],
                                (string)reader["Assessment"]
                            );

                            list.Add(focus);

                        }
                    }

                    return (list);
                }
            }
        }      

        public List<IDengueFocus> GetAll()
        {
            var list = new List<IDengueFocus>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id,IdAddress, IdVisit, Type, IsEradicated, Priority  FROM DengueFocus WHERE ID";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDengueFocus model = new DengueFocus(
                            (int)reader["Id"],
                            (int)reader["IdAddress"],
                            (int)reader["IdVisit"],
                            (bool)reader["IsEradicated"],
                            (MyEnuns.FocusType)reader["Type"],
                            (MyEnuns.Priority)reader["Priority"]
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
