
using Application.Services.UseCases.Dog.DtosDog;
using AutoMapper;

namespace Application.Services.UseCases.Utils
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
                cfg.CreateMap<Domain.Dog, OutputDtoDog>();
                cfg.CreateMap<InputDtoDog, Domain.Dog>();
            });
            return new AutoMapper.Mapper(config);
        }
    }
    
}