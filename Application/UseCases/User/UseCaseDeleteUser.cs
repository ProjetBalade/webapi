using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Services.User
{
    public class UseCaseDeleteUser
    {
        private readonly IUserRepository _userRepository;

        public UseCaseDeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutputDeleteUser Execute(InputDeleteUser dto)
        {
            var idUser = Mapper.GetInstance().Map<Domain.User>(dto).Id;

            var userFromDb = _userRepository.Delete(idUser);

            return Mapper.GetInstance().Map<OutputDeleteUser>(userFromDb);
        }
    }
}