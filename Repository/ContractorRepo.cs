using System.Data;
using System.Data.SqlClient;
using Task1_ContractorV1.Model;

namespace Task1_ContractorV1.Repository
{
    public class ContractorRepo : IContractorRepo
    {
        private readonly string _ConnectionString;
        public ContractorRepo(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public List<Contractor> GetContractorInfo(string NOCIDB, string? SSMNO = null, string? NAMASYARIKAT = null)
        {
            List<Contractor> con = new List<Contractor>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_contractorlist", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cidbregno", NOCIDB);
                    command.Parameters.AddWithValue("@ssmno", (object?)SSMNO ?? DBNull.Value);
                    command.Parameters.AddWithValue("@companyname", (object?)NAMASYARIKAT ?? DBNull.Value);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Contractor cont = new Contractor
                        {
                            CIDBRegno = reader["pkkregno"] != DBNull.Value ? reader["pkkregno"].ToString() : null,
                            SSMNO = reader["ssmno"] != DBNull.Value ? reader["ssmno"].ToString() : null,
                            CompanyName = reader["comname"] != DBNull.Value ? reader["comname"].ToString() : null,
                            kategori = reader["comcategory"] != DBNull.Value ? reader["comcategory"].ToString() : null,
                            ppkexp = reader["ppkenddate"] != DBNull.Value ? (DateTime?)reader["ppkenddate"] : null,
                            gred = reader["comgrade"] != DBNull.Value ? reader["comgrade"].ToString() : null,
                            projekname = reader["prjname"] != DBNull.Value ? reader["prjname"].ToString() : null 
                        };

                        con.Add(cont);
                    }

                }
            }
            return con;
        }

    }
}