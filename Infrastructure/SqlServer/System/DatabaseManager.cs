using System.Data.SqlClient;
using System.IO;

namespace Infrastructure.SqlServer.System
{
    public class DatabaseManager : IDatabaseManager
    {
        public void CreateDatabaseAndTables()
        {
            var script =
                File.ReadAllText(
                    @"C:\Users\elili\RiderProjects\webapi\Infrastructure\SqlServer\Resources\Init.sql");

            var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = script
            };

            command.ExecuteNonQuery();
        }
        
        public void FillTables()
        {
            // TODO: write this method
            var script =
                File.ReadAllText(
                    @"C:\Users\elili\RiderProjects\webapi\Infrastructure\SqlServer\Resources\Data.sql");

            var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = script
            };

            command.ExecuteNonQuery();
        }
    }
    
}