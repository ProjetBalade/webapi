using System.Collections.Generic;
using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Services.User
{
    public class UseCaseGetAllUser : IQuery<List<OutputDtoGetUser>>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetAllUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OutputDtoGetUser> Execute()
        {
            
            var itemFromDb = _userRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoGetUser>>(itemFromDb);
        }

        
    }
}