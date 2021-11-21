using Application.Services.UseCases.Dog.DtosDog;
using Application.Services.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Dog;

namespace Application.Services.UseCases.Dog
{
    public class UseCaseDeleteDog : IDelete<OutputDtoDog>
    {
        private readonly IDogRepository _dogRepository;

        public UseCaseDeleteDog(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        

        public OutputDtoDog Execute(int id)
        {
            var dog = _dogRepository.Delete(id);

            return Mapper.GetInstance().Map<OutputDtoDog>(dog);
        }
    }

}