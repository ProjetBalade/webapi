using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Dog
{
    public class DogRepository : IDogRepository
    {
        public const string TableName = "dog";

        public const string CoLId = "id",
            CoLNameDog = "nameDog",
            CoLRaceDog = "raceDog",
            CoLDateBirth = "dateOfBirth",
            CoLIdUser = "idUser";

        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";
       
        private readonly DogFactory _dogFactory = new DogFactory();
        public List<Domain.Dog> GetAll()
        {
            var dogs = new List<Domain.Dog>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand {Connection = connection, CommandText = ReqGetAll};
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
                dogs.Add(_dogFactory.CreateFromSqlDataReader(reader));
            return dogs;
        }

        public Domain.Dog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.Dog Create(Domain.Dog dog)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Domain.Dog dog)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}