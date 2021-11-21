using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Dog
{
    public interface IDogRepository
    {
        List<Domain.Dog> GetAll();
        Domain.Dog GetById(int id);
        Domain.Dog Create(Domain.Dog dog);
        Domain.Dog Update(int id, Domain.Dog dog);
        void Delete(int id);
    }
}