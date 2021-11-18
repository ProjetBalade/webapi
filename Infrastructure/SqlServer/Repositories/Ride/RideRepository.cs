using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Ride
{
    public class RideRepository : IRideRepository

    {
    public const string TableName = "ride";
    private readonly RideFactory _rideFactory = new RideFactory();

    public const string ColId = "id",
        ColNameRide = "nameRide",
        ColPlace = "place",
        ColDescription = "description",
        ColWebsite = "website",
        ColDifficulty = "difficulty",
        ColSchedule = "schedule",
        ColPhoto = "photo",
        ColScore = "score",
        ColIdUser = "idUser";

    public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";


    public List<Domain.Ride> GetAll()
    {
        var rides = new List<Domain.Ride>();

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


            rides.Add(_rideFactory.CreateFromSqlDataReader(reader));

        }

        return rides;
    }

    public Domain.Ride Create(Domain.Ride ride)
    {
        throw new NotImplementedException();
    }
    }
}