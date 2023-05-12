using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.CarWashStationDtos;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Queries;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{

    [Route("api/car-wash-stations")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]

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
        public async Task<IActionResult> CreateCarWashStationEndpoint([FromForm] CarWashStationDto carWashStationDto, IFormFile File)
        {
            var command = new CreateCarWashStation
            {
                File = File,
                Name = carWashStationDto.Name,
                StandardPrice = carWashStationDto.StandardPrice,
                PremiumPrice = carWashStationDto.PremiumPrice,
                City = carWashStationDto.City,
                Address = carWashStationDto.Address,
                Rank = carWashStationDto.Rank,
                IsSelfWash = carWashStationDto.IsSelfWash,
                ContainerName = AzureContainers.GetCarFlowWashStationsContainer()
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{carWashStationId}")]
        public async Task<IActionResult> DeleteCarWashStation(int carWashStationId)
        {
            var command = new DeleteCarWashStation { 
                CarWashStationId = carWashStationId,
                ContainerName = AzureContainers.GetCarFlowWashStationsContainer()
            };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{carWashStationId}")]
        public async Task<IActionResult> UpdateCarWashStation(int carWashStationId, [FromForm] CarWashStationPatchDto carWashStationDto, IFormFile File)
        {
            var command = new UpdateCarWashStation
            {
                Id = carWashStationId,
                File = File,
                Name = carWashStationDto.Name,
                StandardPrice = carWashStationDto.StandardPrice,
                PremiumPrice = carWashStationDto.PremiumPrice,
                City = carWashStationDto.City,
                Address = carWashStationDto.Address,
                Rank = carWashStationDto.Rank,
                IsSelfWash = carWashStationDto.IsSelfWash,
                ContainerName = AzureContainers.GetCarFlowWashStationsContainer(),
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
