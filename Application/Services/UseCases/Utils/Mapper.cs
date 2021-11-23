using AutoMapper;
using Domain;
using Services.User.Dtos;

namespace Services.UseCases.Utils
{
    public static class Mapper
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
               

                cfg.CreateMap<InputDtoUser, Domain.User>();
                cfg.CreateMap<Domain.User, OutputDtoUser>();
            });
            return new AutoMapper.Mapper(config);
        }
    }
}