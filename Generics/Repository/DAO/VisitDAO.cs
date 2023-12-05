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
    public class VisitDAO
    {
        public static List<IVisit> GetAll()
        {
            var list = new List<IVisit>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, IDAGENT, IDDENUNCIATION, DATAVISIT, ASSESSMENT FROM VISITS;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IVisit model = new Visit(
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            DenunciationDAO.GetOne(reader.GetInt32(3)),
                            reader.GetDateTime(4),
                            reader.GetString(5)
                            );
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public static IVisit GetOne(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdAgent, IdDenunciation, DateVisit, Assement FROM Visits WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Visit(
                            id: reader.GetInt32(0),
                            idAgent: reader.GetInt32(1),
                            denunciation: DenunciationDAO.GetOne(reader.GetInt32(2)),
                            dateVisit: reader.GetDateTime(3),
                            assessment: reader.GetString(4)
                        );
                    }
                }
            }
            return null;
        }
        public static int Insert(IVisit visit)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                int insert = 0;
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO VISITS(IDAGENT, IDDENUNCIATION, DATAVISIT, ASSESSMENT) Output inserted.ID VALUES (@IDAGENT, @IDDENUNCIATION, @DATAVISIT, @ASSESMENT);";

                cmd.Parameters.Add(new SqlParameter("@IDAGENT", visit.IdAgent));
                cmd.Parameters.Add(new SqlParameter("@IDDENUNCIATION", visit.Denunciation.Id));
                cmd.Parameters.Add(new SqlParameter("@DATAVISIT", visit.DateVisit));
                cmd.Parameters.Add(new SqlParameter("@ASSESMENT", visit.Assessment));
                cmd.ExecuteNonQuery();

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
        public static List<IVisit> GetAllVisitsAgent(int id)
        {
            var list = new List<IVisit>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, IDAGENT, IDDENUNCIATION, DATAVISIT, ASSESSMENT FROM VISITS WHERE IDAGENT = @IDAGENT";
                cmd.Parameters.Add(new SqlParameter("@IDAGENT", id));
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IVisit model = new Visit(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            DenunciationDAO.GetOne(reader.GetInt32(2)),
                            reader.GetDateTime(3),
                            reader.GetString(4));

                        list.Add(model);
                    }

                    return list;
                }
            }
        }


        public static void Delete(int id)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Visits WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }

        }
    }
}



