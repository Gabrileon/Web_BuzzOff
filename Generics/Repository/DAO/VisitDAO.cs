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
                            reader.GetInt32(3),
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
                            idDenunciation: reader.GetInt32(2),
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
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO VISITS(IDAGENT, IDDENUNCIATION, DATAVISIT, ASSESSMENT) VALUES (@IDAGENT, @IDDENUNCIATION, @DATAVISIT, @ASSESMENT);";

                cmd.Parameters.Add(new SqlParameter("@IDAGENT", visit.IdAgent));
                cmd.Parameters.Add(new SqlParameter("@IDDENUNCIATION", visit.IdDenunciation));
                cmd.Parameters.Add(new SqlParameter("@DATAVISIT", visit.DateVisit));
                cmd.Parameters.Add(new SqlParameter("@ASSESMENT", visit.Assessment));
                return cmd.ExecuteNonQuery();
                
            }
        }
        public static List<IVisit> GetAllVisitsAgent()
        {
            var list = new List<IVisit>();
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NAME, EMAIL, CPF, ACCESSLEVEL FROM Visit";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //IVisit model = new Visit(
                        //    reader.GetString(1),
                        //    reader.GetString(2),
                        //    reader.GetString(3),
                        //    (MyEnuns.Access)reader.GetInt32(4),
                        //    reader.GetInt32(0));

                        //list.Add(model);
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



