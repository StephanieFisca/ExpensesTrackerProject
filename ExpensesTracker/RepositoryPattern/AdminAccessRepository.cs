using ExpensesTracker.RepositoryPattern.Interfaces;
using System.Data.SqlClient;

namespace ExpensesTracker.Repositories
{
    public class AdminAccessRepository : IAdminAccessRepository
    {
        private readonly SqlConnection _sqlConnection;

        public AdminAccessRepository()
        {
            _sqlConnection = SqlConnectionManager.Instance;
        }

        //Add an admin user to database
        public void AddAdmin(string username, string password)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO AdminAccess (AdminUsername, AdminPassword) VALUES (@username, @password)", _sqlConnection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        //Verify admin username and password
        public bool ValidateAdminCredentials(string username, string password)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM AdminAccess WHERE AdminUsername = @username AND AdminPassword = @password", _sqlConnection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            //retrieves the count of the matching admin credentials
            int count = (int)command.ExecuteScalar();

            _sqlConnection.Close();

            //If 1, user credentials are valid
            return count == 1;
        }

    }
}
