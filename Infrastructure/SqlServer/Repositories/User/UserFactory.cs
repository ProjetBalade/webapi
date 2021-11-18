using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.User
{
    public class UserFactory : IDomainFactory<Domain.User>
    {
        public Domain.User CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.User
            {
                Id = reader.GetInt32(reader.GetOrdinal(UserRepository.ColId)),
                Name = 
                    reader.GetString(reader.GetOrdinal(UserRepository.ColName)),
                Email = reader.GetString(reader.GetOrdinal(UserRepository.colEmail)),
                Password = reader.GetString(reader.GetOrdinal(UserRepository.colPassword))
            };
        }

    }
}