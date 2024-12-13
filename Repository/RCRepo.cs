using System.Data.SqlClient;
using System.Data;
using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public class RCRepo : IRCRepo
    {    
        //repo connect dengan connectionstring
        private readonly string _connectionString;

        public RCRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<RC> GetRCs(string cidbregno, string ssmno, string comname)
        {
            List<RC> RCs = new List<RC>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spNadirahInfo", connection);
                command.CommandType = CommandType.StoredProcedure; // if direct db pakai CommandType.Text
                command.Parameters.AddWithValue("@cidbregno", cidbregno);
                command.Parameters.AddWithValue("@ssmno", ssmno);
                command.Parameters.AddWithValue("@comname", comname);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RC rc = new RC();

                    rc.comname = reader["comname"]?.ToString();
                    rc.pkkregno = reader["pkkregno"]?.ToString();
                    rc.ssmno = reader["ssmno"]?.ToString();
                    rc.PPKEndDate = reader.IsDBNull(reader.GetOrdinal("PPKEndDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("PPKEndDate"));
                    rc.comgrade = reader["comgrade"]?.ToString();
                    rc.comcategory = reader["comcategory"]?.ToString();

                    RCs.Add(rc);

                }
                connection.Close();
            }
            return RCs;
        }
    }
}

