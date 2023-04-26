using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/gas-stations")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]

    public class GasStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GasStationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGasStationsEndpoint()
        {
            var query = new GetAllGasStations();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{gasStationId}")]
        public async Task<IActionResult> GetGasStationById(int gasStationId)
        {
            var query = new GetGasStationById
            {
                Id = gasStationId,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGasStationEndpoint([FromBody] GasStationDto gasStationDto)
        {
            var command = new CreateGasStation
            {
                Name = gasStationDto.Name,
                Fuel = gasStationDto.Fuel,
                City = gasStationDto.City,
                Address = gasStationDto.Address,  
                Rank = gasStationDto.Rank
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{gasStationId}")]
        public async Task<IActionResult> DeleteGasStation(int gasStationId)
        {
            var command = new DeleteGasStation { GasStationId = gasStationId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{gasStationId}")]
        public async Task<IActionResult> UpdateGasStation(int gasStationId, [FromBody] GasStationPatchDto gasStationDto)
        {
            var command = new UpdateGasStation
            {
                Id = gasStationId,
                Name = gasStationDto.Name,
                Fuel = gasStationDto.Fuel,
                City = gasStationDto.City,
                Address = gasStationDto.Address,
                Rank = gasStationDto.Rank
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
