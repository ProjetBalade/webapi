using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Dog
{
    public interface IDogRepository
    {
        List<Domain.Dog> GetAll(int id);
        Domain.Dog GetById(int id);
        Domain.Dog Create(Domain.Dog dog,int id);
        Domain.Dog Update(int id, Domain.Dog dog);
        void Delete(int id);
    }
}