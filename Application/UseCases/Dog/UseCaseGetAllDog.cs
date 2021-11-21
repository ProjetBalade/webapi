using System.Collections.Generic;
using Application.Services.UseCases.Dog.DtosDog;
using Application.Services.UseCases.Utils;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Dog;

namespace Application.Services.UseCases.Dog
{
    public class UseCaseGetAllDog : IQuery<List<OutputDtoDog>>
    {
        private readonly IDogRepository _dogRepository;

        public UseCaseGetAllDog(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public List<OutputDtoDog> Execute()
        {
            var dogs = _dogRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoDog>>(dogs);
        }

        public List<OutputDtoDog> Execute(int id)
        {
            throw new System.NotImplementedException();
        }
    }

}