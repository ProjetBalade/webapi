using System.Collections.Generic;
using Application.Services.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Application.Services.UseCases.User
{
    public class UseCaseGetAllUser : IQuery<List<OutputDtoUser>>
    {
        private readonly IUserRepository _userRepository;

        public UseCaseGetAllUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OutputDtoUser> Execute()
        {
            
            var itemFromDb = _userRepository.GetAll();

            return Mapper.GetInstance().Map<List<OutputDtoUser>>(itemFromDb);
        }

        public List<OutputDtoUser> Execute(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}