using Application.UseCases.Comment.Dtos;
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
                //source, destination
                cfg.CreateMap<InputDtoCreateComment, Domain.Comment>();
                cfg.CreateMap<Domain.Comment, OutputDtoComment>();
            });

            return new AutoMapper.Mapper(config);
        }
    }
    
}