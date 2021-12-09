using Application.UseCases.User.Dtos.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Dtos
{
    public class UseCaseCreateUser
    {
        private readonly IUserRepository _userRepository;

        public UseCaseCreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutPutDtoUser Execute(InputDtoUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);

            var userFromDb = _userRepository.Create(userFromDto);

            return Mapper.GetInstance().Map<OutPutDtoUser>(userFromDb);
        }
    }
}