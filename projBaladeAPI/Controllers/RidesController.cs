using System;
using System.Collections.Generic;
using Application.UseCases.Ride;
using Application.UseCases.Ride.Dtos;
using Application.UseCases.Ride.Exceptions;
using Domain;
using Infrastructure.SqlServer.Repositories.Ride;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace projBaladeAPI.Controllers
{
    [ApiController]
    [Route("api/rides")]
    public class RidesController: ControllerBase
    {
        private readonly IHostEnvironment _environment;
        private readonly IDatabaseManager _databaseManager;
        private readonly IRideRepository _rideRepository;
        private readonly UseCaseGetAllRide _useCaseGetAllRide;
        private readonly UseCaseCreateRide _caseCreateRide;
        private readonly UseCaseUpdateRide _useCaseUpdateRide;
        private readonly UseCaseDeleteRide _useCaseDeleteRide; 
        private readonly UseCaseGetRideById _useCaseGetRideById; 

        public RidesController(IDatabaseManager databaseManager, IHostEnvironment environment, IRideRepository rideRepository,UseCaseGetAllRide useCaseGetAllRide, UseCaseCreateRide useCaseCreateRide,UseCaseUpdateRide updateRide, UseCaseDeleteRide useCaseDeleteRide, UseCaseGetRideById useCaseGetRideById)
        {
            _databaseManager = databaseManager;
            _environment = environment;
            _rideRepository = rideRepository;
            _useCaseGetAllRide = useCaseGetAllRide;
            _caseCreateRide = useCaseCreateRide;
            _useCaseUpdateRide = updateRide;
            _useCaseDeleteRide = useCaseDeleteRide;
            _useCaseGetRideById = useCaseGetRideById;

        }

        [HttpPost]
        [Route("init")]
        public IActionResult CreateDatabaseAndTables()
        {
            if (_environment.IsProduction())
                return BadRequest("Only in dev");
            
            _databaseManager.CreateDatabaseAndTables();
            return Ok("Database and tables created successfully");
        }

        [HttpPost]
        [Route("data")]
        public IActionResult FillTables()
        {
            if (_environment.IsProduction())
                return BadRequest("Only in dev");
            
            _databaseManager.FillTables();
            return Ok("Tables have been filled");
        }
        
         [HttpGet]
         public List<Ride> GetAll()
         {
             return _rideRepository.GetAll();
         }
        // [HttpGet]
        // public ActionResult<OutPutDtoRider> GetAll()
        // {
        //     return _useCaseGetAllRide.Execute();
        // }
        //
        
        [HttpPost]
        public ActionResult<OutPutDtoRide> Create([FromBody] InputDtoRide ride)
        {
            //var validationResult = _userValidator.validateCreateUser(user);
            return StatusCode(201, _caseCreateRide.Execute(ride));
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