using Application.UseCases.Ride.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Ride;

namespace Application.UseCases.Ride
{
    public class UseCaseGetAllRide : IQuery<OutPutDtoRide>
    {
        private readonly IRideRepository _rideRepository;
        private IQuery<OutPutDtoRide> _queryImplementation;

        public UseCaseGetAllRide(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }
        

        public OutPutDtoRide Execute()
        {
            var rideFromDb = _rideRepository.GetAll();

            return Mapper.GetInstance().Map<OutPutDtoRide>(rideFromDb);
        }

        public OutPutDtoRide Execute(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}