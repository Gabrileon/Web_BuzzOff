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
    internal class VisitDAO
    {
        public void Insert(IVisit visit)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Visits (IdAgent, IdDenunciation, DateVisit, Assement) VALUES (@IdAgent, @IdDenunciation, @DateVisit, @Assement)";
                cmd.Parameters.AddWithValue("@IdAgent", visit.IdAgent);
                cmd.Parameters.AddWithValue("@IdDenunciation", visit.IdDenunciation);
                cmd.Parameters.AddWithValue("@DateVisit", visit.DateVisit);
                cmd.Parameters.AddWithValue("@Assement", visit.Assement);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(IVisit visit)
        {
            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Visits SET IdAgent = @IdAgent, IdDenunciation = @IdDenunciation, DateVisit = @DateVisit, Assement = @Assement WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@IdAgent", visit.IdAgent);
                cmd.Parameters.AddWithValue("@IdDenunciation", visit.IdDenunciation);
                cmd.Parameters.AddWithValue("@DateVisit", visit.DateVisit);
                cmd.Parameters.AddWithValue("@Assement", visit.Assement);
                cmd.Parameters.AddWithValue("@Id", visit.Id);
                cmd.ExecuteNonQuery();
            }
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
                            assement: reader.GetString(4)
                        );
                    }
                }
            }

            return null;
        }

        public List<IVisit> GetAll()
        {
            var model = new List<IVisit>();

            using (var conn = new SqlConnection(DBConnect.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, IdAgent, IdDenunciation, DateVisit, Assement FROM Visits";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        model.Add(new Visit(
                            id: reader.GetInt32(0),
                            idAgent: reader.GetInt32(1),
                            idDenunciation: reader.GetInt32(2),
                            dateVisit: reader.GetDateTime(3),
                            assement: reader.GetString(4)
                        ));
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
                cmd.CommandText = "DELETE FROM Visits WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
