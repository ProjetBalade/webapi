using System;
using Application.UseCases.Ride.Dtos;
using AutoMapper;

namespace Application.UseCases.Utils
{
    public class Mapper
    {
        private static AutoMapper.Mapper _instance;

        public static AutoMapper.Mapper GetInstance()
        {
            return _instance ??= CreateMapper();
        }
        
        private static AutoMapper.Mapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Source, Destination
                cfg.CreateMap<Domain.Ride, OutPutDtoRide>();
                cfg.CreateMap<InputDtoRide, Domain.Ride>();
            });
            return new AutoMapper.Mapper(config);
        }
    }
}