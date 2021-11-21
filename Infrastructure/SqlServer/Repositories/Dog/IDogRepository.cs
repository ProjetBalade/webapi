using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Dog
{
    public interface IDogRepository
    {
        List<Domain.Dog> GetAll();
        Domain.Dog GetById(int id);
        Domain.Dog Create(Domain.Dog dog);
        bool Update(int id, Domain.Dog dog);
        bool Delete(int id);
    }
}