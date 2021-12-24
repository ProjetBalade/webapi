using System.Data.SqlClient;

namespace Infrastructure
{
    public class Database
    {
        private const string ConnectionString = "Server = LAPTOP-0UI6MLO7; Database = dbBalade; Integrated Security = SSPI";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}