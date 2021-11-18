using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Dog
{
    public interface IDogRepository
    {
        List<Domain.Dog> GetAll();
        Domain.Dog GetById(int id);
        Domain.Dog Create(string name);
        bool Update(int id, Domain.Dog dog);
        bool Delete(int id);
    }
}