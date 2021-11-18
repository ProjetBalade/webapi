
using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Services.User
{
    public class UseCaseCreateUser
    {
        private readonly IUserRepository _userRepository;

        public UseCaseCreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutputCreateUser Execute(InputCreateUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);

            var userFromDb = _userRepository.Create(userFromDto);

            return Mapper.GetInstance().Map<OutputCreateUser>(userFromDb);
        }
    }
}
