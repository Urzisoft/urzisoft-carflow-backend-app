using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.CarWashStationDtos;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{

    [Route("api/carWashStation")]
    [ApiController]
    public class CarWashStationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarWashStationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarWashStationsEndpoint()
        {
            var query = new GetAllCarWashStations();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{carWashStationId}")]
        public async Task<IActionResult> GetCarWashStationById(int carWashStationId)
        {
            var query = new GetCarWashStationById
            {
                Id = carWashStationId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarWashStationEndpoint([FromBody] CarWashStationDto carWashStationDto)
        {
            var command = new CreateCarWashStation
            {
               Name = carWashStationDto.Name,
               StandardPrice = carWashStationDto.StandardPrice,
               PremiumPrice = carWashStationDto.PremiumPrice,
               Location = carWashStationDto.Location,
               Address = carWashStationDto.Address,
               Rank = carWashStationDto.Rank,
               IsSelfWash = carWashStationDto.IsSelfWash
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{carWashStationId}")]
        public async Task<IActionResult> DeleteCarWashStation(int carWashStationId)
        {
            var command = new DeleteCarWashStation { CarWashStationId = carWashStationId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
