using System.Data;
using System.Data.SqlClient;
using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public class UsersRepo : IUsersRepo
    {
        private readonly string _connectionString;

        public UsersRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetBasicDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users();

                    user.FirstName = reader["APPUS_FIRSTNAME"]?.ToString();
                    user.LastName = reader["APPUS_LASTNAME"]?.ToString();

                    users.Add(user);

                }
                connection.Close();
            }
            return users;

        }



    }
}
