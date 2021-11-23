using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.User
{
    public partial class UserRepository : IUserRepository
    {
        private readonly IDomainFactory<Domain.User> _userFactory = new UserFactory();
        public List<Domain.User> GetAll()
        {
            var users = new List<Domain.User>();

            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetAll
            };

          

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                users.Add(_userFactory.CreateFromSqlReader(reader));
            }
            return  users;
        }
        
        public Domain.User Create(Domain.User user)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };

            command.Parameters.AddWithValue("@" + ColName, user.Name);
            command.Parameters.AddWithValue("@" + colEmail, user.Email);
            command.Parameters.AddWithValue("@" + colPassword, user.Password);

            user.Id = (int) command.ExecuteScalar();

            return user;
        }
        
        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqDelete
            };
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;

        }

        public Domain.User GetById(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetById
            };

            command.Parameters.AddWithValue("@" + ColId, id);
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader.Read() ? _userFactory.CreateFromSqlReader(reader) : null;
        }

        public bool Update(int id, Domain.User user)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdate
            };
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColName, user.Name);
            command.Parameters.AddWithValue("@" + colEmail, user.Email);
            command.Parameters.AddWithValue("@" + colPassword, user.Password);

            return command.ExecuteNonQuery() > 0;
        }
    }
}