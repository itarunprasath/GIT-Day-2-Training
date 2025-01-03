using System.Data.SqlClient;
using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public class PrjInfoRepo : IPrjInfoRepo
    {
        private readonly string _connectionString;

        public PrjInfoRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PrjInfo> GetProjectInfo(string comprefno)
        {
            List<PrjInfo> prjInfos = new List<PrjInfo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spHGetPrjInfoByCompregno", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("RegNoOrSSMNo", comprefno);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PrjInfo prjInfo = new PrjInfo();

                    prjInfo.ProjectReferenceNo = reader.IsDBNull(reader.GetOrdinal("PrjRefNo")) ? (String?)null : reader.GetString(reader.GetOrdinal("PrjRefNo"));
                    prjInfo.ProjectTitle = reader.IsDBNull(reader.GetOrdinal("TajukProjek")) ? (String?)null : reader.GetString(reader.GetOrdinal("TajukProjek"));
                    prjInfo.ProjectValue = reader.IsDBNull(reader.GetOrdinal("NilaiProjek")) ? (Decimal?)null : reader.GetDecimal(reader.GetOrdinal("NilaiProjek"));
                    prjInfo.ProjectAwardDate = reader.IsDBNull(reader.GetOrdinal("TkhAnugerah")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("TkhAnugerah"));
                    prjInfo.CompanyRegisterNo = reader.IsDBNull(reader.GetOrdinal("NoDaftarSykt")) ? (String?)null : reader.GetString(reader.GetOrdinal("NoDaftarSykt"));
                    prjInfo.CIDBRegistrationNo = reader.IsDBNull(reader.GetOrdinal("NoDaftarCIDB")) ? (String?)null : reader.GetString(reader.GetOrdinal("NoDaftarCIDB"));
                    prjInfo.CompanyName = reader.IsDBNull(reader.GetOrdinal("NamaSykt")) ? (String?)null : reader.GetString(reader.GetOrdinal("NamaSykt"));

                    prjInfos.Add(prjInfo);
                }
                connection.Close();

            }
            return prjInfos;

        }


    }
}
