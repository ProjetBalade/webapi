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
               

                cfg.CreateMap<InputDtoGetUser, Domain.User>();
                cfg.CreateMap<Domain.User, OutputDtoGetUser>();
                cfg.CreateMap<InputCreateUser, Domain.User>();
                cfg.CreateMap<Domain.User, OutputCreateUser>();
                cfg.CreateMap<InputDeleteUser, Domain.User>();
                cfg.CreateMap<Domain.User, OutputDeleteUser>();
            });
            return new AutoMapper.Mapper(config);
        }
    }
}