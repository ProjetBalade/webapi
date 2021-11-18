using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.User;
using Services.User.Dtos;

namespace projBaladeAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UseCaseGetAllUser _useCaseGetAllUser;
        private readonly UseCaseCreateUser _useCaseCreateUser;
        private readonly UseCaseDeleteUser _useCaseDeleteUser;

        public UserController(
            UseCaseGetAllUser useCaseGetAllUser,
            UseCaseCreateUser useCaseCreateUser,
            UseCaseDeleteUser useCaseDeleteUser)
        {
            _useCaseGetAllUser = useCaseGetAllUser;
            _useCaseCreateUser = useCaseCreateUser;
            _useCaseDeleteUser = useCaseDeleteUser;
        }

        [HttpGet]
        public ActionResult<List<OutputDtoGetUser>> GetAll()
        {

            return _useCaseGetAllUser.Execute();

        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputCreateUser> Create(InputCreateUser dto)
        {
            return StatusCode(201, _useCaseCreateUser.Execute(dto));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDeleteUser> Delete(int id)
        {
            return StatusCode(201, _useCaseDeleteUser.Execute(dto));
        }

    }
}