using Application.UseCases.User.Dtos.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Dtos
{
    public class UseCaseUpdateUser : IUpdate<OutPutDtoUser, InputDtoUser>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseUpdateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutPutDtoUser Execute(int id, InputDtoUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);

            var user = _userRepository.Update(id,userFromDto);

            return Mapper.GetInstance().Map<OutPutDtoUser>(user);
        }
    }
}