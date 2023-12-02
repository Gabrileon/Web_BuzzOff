using Business.Repository.DAO;
using Business.Repository;
using Common.Interfaces;
using Microsoft.Data.SqlClient;
using static Common.Others.MyEnuns;
using Common.Others;

namespace Business.Generics
{
    public class Denunciation : IDenunciation
    {
        public Denunciation()
        {
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idInformer"></param>
        /// <param name="address"></param>
        /// <param name="comment"></param>
        /// <param name="focusType"></param>
        /// <param name="media"></param>
        /// <param name="stage"></param>
        /// <param name="isAnswered"></param>
        /// <param name="dataDenunciation"></param>
        public Denunciation(int id, int idInformer, IAddress address, string comment, MyEnuns.FocusType focusType, byte[] media, MyEnuns.DenunciationStage stage, bool isAnswered, DateTime dataDenunciation)
        {
            Id = id;
            IdInformer = idInformer;
            Address = address;
            Comment = comment;
            FocusType = focusType;
            Media = media;
            Stage = stage;
            IsAnswered = isAnswered;
            DataDenunciation = dataDenunciation;
        }

        public int Id { get; set; }
        public int IdInformer { get; set; }
        public IAddress Address { get; set; }
        public string Comment { get; set; }
        public MyEnuns.FocusType FocusType { get; set; }
        public byte[]? Media { get; set; }
        public MyEnuns.DenunciationStage Stage { get; set; }
        public bool IsAnswered { get; set; }
        public DateTime DataDenunciation { get; set; }

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
    }
}
