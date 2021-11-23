using System;
using System.Collections.Generic;
using Application.Services.UseCases.User;
using Domain;
using Infrastructure.SqlServer.Repositories.User;
using Infrastructure.SqlServer.Repositories.User.Exceptions;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UseCaseGetUser _useCaseGetUser;
        private readonly UseCaseUpdateUser _useCaseUpdateUser;
        private IUserRepository _userRepository;

        public UserController(
            UseCaseGetAllUser useCaseGetAllUser,
            UseCaseCreateUser useCaseCreateUser,
            UseCaseDeleteUser useCaseDeleteUser,
            UseCaseGetUser useCaseGetUser,
            UseCaseUpdateUser useCaseUpdateUser,
            IUserRepository userRepository)
        {
            _useCaseGetAllUser = useCaseGetAllUser;
            _useCaseCreateUser = useCaseCreateUser;
            _useCaseDeleteUser = useCaseDeleteUser;
            _useCaseGetUser = useCaseGetUser;
            _useCaseUpdateUser = useCaseUpdateUser;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<OutputDtoUser>> GetAll()
        {

            return _useCaseGetAllUser.Execute();

        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoUser> GetById(int id)
        {
            try
            {
                return StatusCode(200,_useCaseGetUser.Execute(id));
            }
            catch (UserNotFoundException e)
            {
                
                return StatusCode(404);
            }
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoUser> Create(InputDtoUser dto)
        {
            return StatusCode(201, _useCaseCreateUser.Execute(dto));
        }
        

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult Delete(int id)
        {
            if (_userRepository.Delete(id))
            {
                return Ok();
            }

            return NotFound();
        }
        
        
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<OutputDtoUser> Update(int id, InputDtoUser user)
        {
            try
            {
                return StatusCode(200, _useCaseUpdateUser.Execute(id, user));
            }
            catch (UserNotFoundException e)
            {
                return StatusCode(404);
            }
        }

    }
    
}