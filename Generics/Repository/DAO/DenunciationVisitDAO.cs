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
    public class DenunciationVisitDAO
    {
        public static void Insert(IDenunciationVisit denunciationsVisits)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DenunciationsVisits (IDDENUNCIATION, IDVISIT) " +
                    "VALUES (@IDVISIT, @IDDENUNCIATION)";
                cmd.Parameters.AddWithValue("@IDDENUNCIATION", denunciationsVisits.Denunciation.Id);
                cmd.Parameters.AddWithValue("@IDVISIT", denunciationsVisits.Visit.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(IDenunciationVisit denunciationsVisits)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE DenunciationsVisits SET IDVISIT = @IDVISIT, " +
                    "IDDENUNCIATION = @IDDENUNCIATION WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@IDVISIT", denunciationsVisits.Visit.Id);
                cmd.Parameters.AddWithValue("@IDDENUNCIATION", denunciationsVisits.Denunciation.Id);

                cmd.Parameters.AddWithValue("@Id", denunciationsVisits.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static IDenunciationVisit GetOne(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IDVISIT, IDDENUNCIATION FROM DenunciationsVisits WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IDenunciationVisit model = new DenunciationsVisit()
                        {
                            Id = (int)reader["ID"],
                            Visit = VisitDAO.GetOne((int)reader["VISIT"]),
                            Denunciation = DenunciationDAO.GetOne((int)reader["IDDENUNCIATION"])
                        };
                        return model;

                    }
                }
            }

            return null;
        }

        public static List<IDenunciationVisit> GetAll()
        {
            var model = new List<IDenunciationVisit>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IDVISIT, IDDENUNCIATION FROM DenunciationsVisits";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Add(new DenunciationsVisit()
                        {

                            Id = (int)reader["ID"],
                            Visit = VisitDAO.GetOne((int)reader["VISIT"]),
                            Denunciation = DenunciationDAO.GetOne((int)reader["IDDENUNCIATION"])

                        });
                    }
                }
            }

            return model;
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM DenunciationsVisits WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
