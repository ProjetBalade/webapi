using Application.UseCases.Ride.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Ride;

namespace Application.UseCases.Ride
{
    public class UseCaseCreateRide : IWriting<OutPutDtoRide,InputDtoRide>
    {
        private readonly IRideRepository _rideRepository;

        public UseCaseCreateRide(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }
        public OutPutDtoRide Execute(InputDtoRide dto)
        {
            var rideFromDto = Mapper.GetInstance().Map<Domain.Ride>(dto);

            var userFromDb = _rideRepository.Create(rideFromDto);

            return Mapper.GetInstance().Map<OutPutDtoRide>(userFromDb);
        }

        public OutPutDtoRide Execute(InputDtoRide dto, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}