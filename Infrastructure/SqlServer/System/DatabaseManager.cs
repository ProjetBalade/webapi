using System.Data.SqlClient;
using System.IO;

namespace Infrastructure.SqlServer.System
{
    public class DatabaseManager : IDatabaseManager
    {
        public void CreateDatabaseAndTables()
        {
            ReadAndExecuteFile(
                @"/Users/aleynabastu/RiderProjects/projetBalade/webapi/Infrastructure/SqlServer/Resources/Init.sql");
        }

        public void FillTables()
        {
            ReadAndExecuteFile(
                @"/Users/aleynabastu/RiderProjects/projetBalade/webapi/Infrastructure/SqlServer/Resources/Data.sql");
        }
        
        private static void ReadAndExecuteFile(string filePath)
        {
            var script = File.ReadAllText(filePath);

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