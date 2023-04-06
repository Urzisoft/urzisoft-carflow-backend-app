using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/gas-stations")]
    [ApiController]
    public class GasStationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GasStationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGasStationEndpoint([FromBody] GasStationDto GasStationDto)
        {
            var command = new CreateGasStation
            {
                Gas = GasStationDto.Gas,
                City = GasStationDto.City,
                Address = GasStationDto.Address,
            };

            var result = await _mediator.Send(command);
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllGasStationsEndpoint()
        {
            var query = new GetAllGasStations();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
