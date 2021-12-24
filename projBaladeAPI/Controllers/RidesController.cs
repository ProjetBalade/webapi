using System;
using System.Collections.Generic;
using Application.UseCases.Ride;
using Application.UseCases.Ride.Dtos;
using Application.UseCases.Ride.Exceptions;
using Application.UseCases.User;
using Domain;
using Infrastructure.SqlServer.Repositories.Ride;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using projBaladeAPI.Helpers;

namespace projBaladeAPI.Controllers
{
    [ApiController]
    [Route("api/rides")]
    public class RidesController: ControllerBase
    {
       
        private readonly UseCaseGetAllRide _useCaseGetAllRide;
        private readonly UseCaseCreateRide _caseCreateRide;
        private readonly UseCaseUpdateRide _useCaseUpdateRide;
        private readonly UseCaseDeleteRide _useCaseDeleteRide; 
        private readonly UseCaseGetRideById _useCaseGetRideById; 
        
        //admin use case
        private readonly UseCaseGetAllPendingRide _useCaseGetAllPendingRide;
        private readonly UseCaseRefuseRide _useCaseRefuseRide;
        private readonly UseCaseValidateRide _useCaseValidateRide;
        private readonly UseCaseIsAdmin _useCaseIsAdmin;


        public RidesController(UseCaseGetAllRide useCaseGetAllRide, UseCaseCreateRide useCaseCreateRide,UseCaseUpdateRide updateRide, UseCaseDeleteRide useCaseDeleteRide, UseCaseGetRideById useCaseGetRideById,UseCaseGetAllPendingRide useCaseGetAllPendingRide,UseCaseValidateRide useCaseValidateRide, UseCaseRefuseRide useCaseRefuseRide, UseCaseIsAdmin useCaseIsAdmin)
        {
         
            _useCaseGetAllRide = useCaseGetAllRide;
            _caseCreateRide = useCaseCreateRide;
            _useCaseUpdateRide = updateRide;
            _useCaseDeleteRide = useCaseDeleteRide;
            _useCaseGetRideById = useCaseGetRideById;
            _useCaseGetAllPendingRide = useCaseGetAllPendingRide;
            _useCaseValidateRide = useCaseValidateRide;
            _useCaseRefuseRide = useCaseRefuseRide;
            _useCaseIsAdmin = useCaseIsAdmin;

        }

       
     
        
        [Authorize]
        [HttpGet]
        public ActionResult<List<OutPutDtoRide>> GetAll()
        {
            return _useCaseGetAllRide.Execute();
        }
        
        [Authorize]
        [HttpGet]
        [Route("pending")]
        public ActionResult<List<OutPutDtoRide>> GetAllPendingRide()
        {
            if (HttpContext.Items["User"] is User user && _useCaseIsAdmin.Execute(user.Id))
            {
                return _useCaseGetAllPendingRide.Execute();
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("{id:int}/accept")]
        public ActionResult<OutPutDtoRide> ValidateRide(int id)
        {
            if (HttpContext.Items["User"] is User user && _useCaseIsAdmin.Execute(user.Id))
            {
                return StatusCode(200, _useCaseValidateRide.Execute(id));
            }

            return Unauthorized();
        }
        
        [HttpPost]
        [Route("{id:int}/refuse")]
        public ActionResult<bool> RefuseRide(int id)
        {
            if (HttpContext.Items["User"] is User user && _useCaseIsAdmin.Execute(user.Id))
            {
                _useCaseRefuseRide.Execute(id);
                return StatusCode(200, true);
            }

            return Unauthorized();
        }
        
        [HttpPost]
        public ActionResult<OutPutDtoRide> Create([FromBody] InputDtoRide ride)
        {
            if (HttpContext.Items["User"] is User user)
            {
                int userId = user.Id;
                return StatusCode(201, _caseCreateRide.Execute(ride,userId));
            }
            //var validationResult = _userValidator.validateCreateUser(user);
            return Unauthorized();
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<OutPutDtoRide> Update(int id, [FromBody] InputDtoRide ride)
        {
            try
            {
                return StatusCode(200, _useCaseUpdateRide.Execute(id, ride));
            }
            catch (RideNotFoundException e)
            {
                return StatusCode(404);
            }
            
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<bool> Delete(int id)
        {
            if (_useCaseDeleteRide.Execute(id))
            {
                return Ok();
            }

            return NotFound();
            
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutPutDtoRide> GetById(int id)
        {
            return StatusCode(200,_useCaseGetRideById.Execute(id));
        }
    }
}