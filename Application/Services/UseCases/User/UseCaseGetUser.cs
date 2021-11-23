using Application.Services.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Application.Services.UseCases.User
{
    public class UseCaseGetUser : IQuery<OutputDtoUser>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OutputDtoUser Execute()
        {
            throw new System.NotImplementedException();
        }

        public OutputDtoUser Execute(int id)
        {
            var dog = _userRepository.GetById(id);

            return Mapper.GetInstance().Map<OutputDtoUser>(dog);
        }
    }

}