using System.Data;
using System.Data.SqlClient;
using Task1_Score.Model;

namespace Task1_Score.Repository
{
    public class ScoreRepo: IScoreRepo
    {
        private readonly string _ConnectionString;
        //private object scoreAPPl;
        public ScoreRepo(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<ScoreAppl>GetScoreAppl(string GRED, int BINTANG, int TAHUN)
        {
            List<ScoreAppl> scoreAppls = new List<ScoreAppl>();

            using (SqlConnection connection=new SqlConnection(_ConnectionString)) 
            { 
               using  (SqlCommand command = new SqlCommand("sp_ScoreApplSiti", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // command.Parameters.AddWithValue("@SCORENO", appl);
                    command.Parameters.AddWithValue("@GRADE", GRED);
                    command.Parameters.AddWithValue("@STAR", BINTANG);
                    command.Parameters.AddWithValue("@YEARS", TAHUN);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ScoreAppl scoreAppl = new ScoreAppl();

                        scoreAppl.scoreno = reader.GetString("SCAP_APPLICATION_NO");
                        scoreAppl.companyname = reader.GetString("COMNAME");
                        scoreAppl.cidbno = reader.GetString("pkkregno");
                        scoreAppl.grade = reader.GetString("COMGRADE");
                        scoreAppl.star = reader.GetByte("SCSTAR_SCORESTAR");
                        scoreAppl.ppkexp = reader.GetDateTime("ppkenddate");
                        scoreAppl.category = reader.GetString(reader.GetOrdinal("ComCategory"));
                        scoreAppl.scoredate = reader.GetDateTime("scap_approved_date");


                        //walls.displayorder = reader.GetByte(reader.GetOrdinal("walsys_displayorder"));


                        scoreAppls.Add(scoreAppl);
                    }
                }
            }


            return scoreAppls;
        }
    }
}

