using Application.Services.UseCases.Utils;
using Application.UseCases.User.Dtos.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User.Dtos
{
    public class UseCaseDeleteUser : IDelete<OutPutDtoUser>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseDeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public OutPutDtoUser Execute(int id)
        {
            var user = _userRepository.Delete(id);

            return Mapper.GetInstance().Map<OutPutDtoUser>(user);
        }
    }
}