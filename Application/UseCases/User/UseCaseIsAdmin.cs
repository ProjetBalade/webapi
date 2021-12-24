using Infrastructure.SqlServer.Repositories.User;

namespace Application.UseCases.User
{
    public class UseCaseIsAdmin
    {
        private readonly IUserRepository _userRepository;

        public UseCaseIsAdmin(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public bool Execute(int id)
        {
            return _userRepository.isAdmin(id);
        }
    }
}