using System.Data.SqlClient;

namespace Infrastructure
{
    public class Database
    {
        private const string ConnectionString = "Server=DESKTOP-L97KEOS;Database=dbBalade;Integrated Security=SSPI";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}