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
    public class VisitSolicitationDAO
    {
        public static void Insert(IVisitSolicitation visitSolicitation)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO VisitsSolicitations (IDVISIT, IDSOLICITATION) " +
                    "VALUES (@IDVISIT, @IDSOLICITATION)";
                cmd.Parameters.AddWithValue("@IDVISIT", visitSolicitation.Visit.Id);
                cmd.Parameters.AddWithValue("@IDSOLICITATION", visitSolicitation.Solicitation.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(IVisitSolicitation visitSolicitation)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE VisitsSolicitations SET IDVISIT = @IDVISIT, " +
                    "IDSOLICITATION = @IDSOLICITATION WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@IDVISIT", visitSolicitation.Visit.Id);
                cmd.Parameters.AddWithValue("@IDSOLICITATION", visitSolicitation.Solicitation.Id);

                cmd.Parameters.AddWithValue("@Id", visitSolicitation.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static IVisitSolicitation GetOne(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IDVISIT, IDSOLICITATION FROM VisitsSolicitations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IVisitSolicitation model = new VisitSolicitation()
                        {
                            Id = (int)reader["ID"],
                            Visit = VisitDAO.GetOne((int)reader["VISIT"]),
                            Solicitation = SolicitationDAO.GetOne((int)reader["SOLICITATION"])
                        };
                        return model;

                    }
                }
            }

            return null;
        }

        public static List<IVisitSolicitation> GetAll()
        {
            var model = new List<IVisitSolicitation>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IDVISIT, IDSOLICITATION FROM VisitsSolicitations";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Add(new VisitSolicitation()
                        {

                            Id = (int)reader["ID"],
                            Visit = VisitDAO.GetOne((int)reader["VISIT"]),
                            Solicitation = SolicitationDAO.GetOne((int)reader["SOLICITATION"])

                        });
                    }
                }
            }

            return model;
        }

        public static void Delete(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM VisitsSolicitations WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
