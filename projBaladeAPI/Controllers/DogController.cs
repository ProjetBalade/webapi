using System.Collections.Generic;
using Application.Services.UseCases.Dog;
using Application.Services.UseCases.Dog.DtosDog;
using Domain;
using Infrastructure.SqlServer.Repositories.Dog;
using Microsoft.AspNetCore.Mvc;


namespace projBaladeAPI.Controllers
{
    [ApiController]
    [Route("api/dog")]
    public class DogController : ControllerBase
    {
        private readonly UseCaseGetAllDog _useCaseGetAllDog;
        private readonly UseCaseGetDog _useCaseGetDog;
        private readonly UseCaseCreateDog _useCaseCreateDog;
        private readonly UseCaseUpdateDog _useCaseUpdateDog;
        private readonly UseCaseDeleteDog _useCaseDeleteDog;

        public DogController(UseCaseGetAllDog useCaseGetAllDog, UseCaseGetDog useCaseGetDog, UseCaseCreateDog useCaseCreateDog, UseCaseUpdateDog useCaseUpdateDog, UseCaseDeleteDog useCaseDeleteDog)
        {
            _useCaseGetAllDog = useCaseGetAllDog;
            _useCaseGetDog = useCaseGetDog;
            _useCaseCreateDog = useCaseCreateDog;
            _useCaseUpdateDog = useCaseUpdateDog;
            _useCaseDeleteDog = useCaseDeleteDog;
        }
        

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<OutputDtoDog>> GetAll()
        {
            return _useCaseGetAllDog.Execute();
        }
        
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoDog> Create([FromBody] InputDtoDog dog)
        {
            return _useCaseCreateDog.Execute(dog);
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Update(int id, [FromBody] InputDtoDog dog)
        {
            return StatusCode(200,_useCaseUpdateDog.Execute(id, dog)); //Entourer d'un try catch ! creer exception 
        }

    }
}