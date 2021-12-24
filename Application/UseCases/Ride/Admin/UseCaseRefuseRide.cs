using Application.UseCases.Ride.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Ride;

namespace Application.UseCases.Ride
{
    public class UseCaseRefuseRide
    {
        private readonly IRideRepository _rideRepository;
        
        public UseCaseRefuseRide(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        public void Execute(int id)
        {
            _rideRepository.Delete(id);
        }
    }
}