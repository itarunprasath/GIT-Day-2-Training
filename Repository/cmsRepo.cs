using System.Data;
using System.Data.SqlClient;
using Task1_CMS.Model;

namespace Task1_CMS.Repository
{
    public class CmsRepo : IcmsRepo
    {
        private readonly string _ConnectionString;

        public CmsRepo(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<CMS> GetInfoCMS(string? ICNO = null, string? TRED = null)
        {
            List<CMS> competency = new List<CMS>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_cmssiti", connection))
                {
                    //command.CommandType = CommandType.StoredProcedure;
                    // command.Parameters.AddWithValue("@SCORENO",appl);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ICNO", (object?)ICNO ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TRED", (object?)TRED ?? DBNull.Value);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //CMS cms = new CMS();
                        //cms.name = reader.GetString("PCPD_NAME");
                        //cms.icno = reader.GetString("PCPD_ICNO");
                        //cms.category = reader.GetString("PCA_ACMCP_CODE");

                        CMS cms = new CMS
                        {
                            name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null,
                            icno = reader["ICno/Passport"] != DBNull.Value ? reader["ICno/Passport"].ToString() : null,
                            dob = reader["dateofbirth"] != DBNull.Value ? reader["dateofbirth"].ToString() : null,
                            category = reader["TredCode"] != DBNull.Value ? reader["TredCode"].ToString() : null,
                            certno = reader["PCAD_CERT_NO"] != DBNull.Value ? reader["PCAD_CERT_NO"].ToString() : null,
                            ass = reader["Assessment_Location"] != DBNull.Value ? reader["Assessment_Location"].ToString() : null,
                            race = reader["bangsa"] != DBNull.Value ? reader["bangsa"].ToString() : null,
                            CardNo = reader["nokadhijau"] != DBNull.Value ? reader["nokadhijau"].ToString() : null
                        };
                        competency.Add(cms);

                    }
                }
            }
            return competency;

        }

    }
}
