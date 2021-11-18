using Infrastructure.SqlServer.Repositories.Dog;
using Microsoft.AspNetCore.Mvc;
//using Services.UseCases.VideoGame;
//using Services.UseCases.VideoGame.Dtos;

namespace projBaladeAPI.Controllers
{
    [ApiController]
    [Route("api/dog")]
    public class DogController : ControllerBase
    {
        /*private readonly UseCaseCreateVideoGame _useCaseCreateVideoGame;

        public VideoGameController(UseCaseCreateVideoGame useCaseCreateVideoGame)
        {
            _useCaseCreateVideoGame = useCaseCreateVideoGame;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoVideoGame> Create(InputDtoVideoGame dto)
        {
            return StatusCode(201, _useCaseCreateVideoGame.Execute(dto));
        }*/
    }
}