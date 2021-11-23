using Application.Services.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.User;
using Services.UseCases.Utils;
using Services.User.Dtos;

namespace Application.Services.UseCases.User
{
    public class UseCaseDeleteUser: IDelete<OutputDtoUser>

    {
    private readonly IUserRepository _userRepository;

    public UseCaseDeleteUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public OutputDtoUser Execute(int id)
    {
        var user = _userRepository.Delete(id);

        return Mapper.GetInstance().Map<OutputDtoUser>(user);
    }
    }
}