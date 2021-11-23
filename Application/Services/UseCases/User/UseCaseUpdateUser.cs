using Application.Services.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Application.Services.UseCases.User
{
    public class UseCaseUpdateUser : IUpdate<OutputDtoUser, InputDtoUser>
    {
        private readonly IUserRepository _userRepository;
        
        public UseCaseUpdateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public OutputDtoUser Execute(int id, InputDtoUser dto)
        {
            var userFromDto = Mapper.GetInstance().Map<Domain.User>(dto);

            var user = _userRepository.Update(id,userFromDto);

            return Mapper.GetInstance().Map<OutputDtoUser>(user);
        }
    }
}