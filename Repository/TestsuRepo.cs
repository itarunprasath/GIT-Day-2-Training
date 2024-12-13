using System.Data.SqlClient;
using System.Data;
using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public class TestsuRepo : ITestsuRepo
    {
        private readonly string _connectionString;
        public TestsuRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<TestsuDetails> GetUserDetails()
        {
            List<TestsuDetails> userDetails = new List<TestsuDetails>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetBasicDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TestsuDetails userDetail = new TestsuDetails();

                    userDetail.AppUserUniqueId = reader.IsDBNull(reader.GetOrdinal("APPUS_UNIQUEID")) ? Guid.Empty : (Guid)reader["APPUS_UNIQUEID"];
                    userDetail.UserId = reader["APPUS_USERID"]?.ToString();
                    userDetail.NRICPassport = reader["APPUS_NRICPASSPORT"]?.ToString();
                    userDetail.FirstName = reader["APPUS_FIRSTNAME"]?.ToString();
                    userDetail.LastName = reader["APPUS_LASTNAME"]?.ToString();

                    userDetails.Add(userDetail);
                }


                reader.Close();
            }



            return userDetails;
        }


        public TestsuDetails GetUserDetailsByUserid(string userId)
        {
            TestsuDetails userDetail = new TestsuDetails();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetBasicDetailsByUserID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    userDetail.AppUserUniqueId = reader.IsDBNull(reader.GetOrdinal("APPUS_UNIQUEID")) ? Guid.Empty : (Guid)reader["APPUS_UNIQUEID"];
                    userDetail.UserId = reader["APPUS_USERID"]?.ToString();
                    userDetail.NRICPassport = reader["APPUS_NRICPASSPORT"]?.ToString();
                    userDetail.FirstName = reader["APPUS_FIRSTNAME"]?.ToString();
                    userDetail.LastName = reader["APPUS_LASTNAME"]?.ToString();

                }


                reader.Close();
            }



            return userDetail;
        }
    }

}
