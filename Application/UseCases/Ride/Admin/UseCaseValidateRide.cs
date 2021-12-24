using Application.UseCases.Ride.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Ride;

namespace Application.UseCases.Ride
{
    public class UseCaseValidateRide
    {
        private readonly IRideRepository _rideRepository;
        
        public UseCaseValidateRide(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        public OutPutDtoRide Execute(int id)
        {
            var ride = _rideRepository.GetById(id);

             ride.Accepted = true;

            var updateFromDb = _rideRepository.Update(id, ride);

            return Mapper.GetInstance().Map<OutPutDtoRide>(updateFromDb);
        }
    }
}