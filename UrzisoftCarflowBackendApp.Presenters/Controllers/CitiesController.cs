using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.CityDtos;
using UrzisoftCarflowBackendApp.UseCases.Cities.Commands;
using UrzisoftCarflowBackendApp.UseCases.Cities.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCitiesEndpoint()
        {
            var query = new GetAllCities();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{cityId}")]
        public async Task<IActionResult> GetCityById(int cityId)
        {
            var query = new GetCityById
            {
                Id = cityId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCityEndpoint([FromBody] CityDto cityDto)
        {
            var command = new CreateCity
            {
                Name = cityDto.Name,
                County = cityDto.County,
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{cityId}")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            var command = new DeleteCity { CityId = cityId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{cityId}")]
        public async Task<IActionResult> UpdateCity(int cityId, [FromBody] CityPatchDto cityDto)
        {
            var command = new UpdateCity
            {
                Id = cityId,
                Name = cityDto.Name,
                County = cityDto.County,
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
