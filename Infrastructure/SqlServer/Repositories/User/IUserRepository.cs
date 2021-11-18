using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.User
{
    public interface IUserRepository
    {
        List<Domain.User> GetAll();
        Domain.User Create(Domain.User user);

        bool Delete(int id);
    }
}