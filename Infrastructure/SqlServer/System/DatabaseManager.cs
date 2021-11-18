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
                    @"C:\Users\nicod\Documents\Ecole\HELHa\BAC3\Projet\ProjetBalade\Infrastructure\SqlServer\Resources\Init.sql");

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
            var script =
                File.ReadAllText(
                    @"C:\Users\nicod\Documents\Ecole\HELHa\BAC3\Projet\ProjetBalade\Infrastructure\SqlServer\Resources\Data.sql");

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