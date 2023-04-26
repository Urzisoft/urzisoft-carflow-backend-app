using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.FuelDtos;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Commands;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/fuels")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]
    public class FuelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FuelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFuelsEndpoint()
        {
            var query = new GetAllFuels();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{fuelId}")]
        public async Task<IActionResult> GetFuelById(int fuelId)
        {
            var query = new GetFuelById
            {
                Id = fuelId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFuelEndpoint([FromBody] FuelDto fuelDto)
        {
            var command = new CreateFuel
            {
                Name = fuelDto.Name,
                Description = fuelDto.Description,
                Type = fuelDto.Type,
                Quality = fuelDto.Quality,
                Price = fuelDto.Price,
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{fuelId}")]
        public async Task<IActionResult> DeleteFuel(int fuelId)
        {
            var command = new DeleteFuel{ FuelId = fuelId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{fuelId}")]
        public async Task<IActionResult> UpdateFuel(int fuelId, [FromBody] FuelPatchDto fuelDto)
        {
            var command = new UpdateFuel
            {
                Id = fuelId,
                Name = fuelDto.Name,
                Description = fuelDto.Description,
                Type = fuelDto.Type,
                Quality = fuelDto.Quality,
                Price = fuelDto.Price,
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
