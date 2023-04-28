using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Commands;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Queries;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/car-services")]
    [ApiController]
    public class CarServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarServicesEndpoint()
        {
            var query = new GetAllCarServices();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{carServiceId}")]
        public async Task<IActionResult> GetCarServiceById(int carServiceId)
        {
            var query = new GetCarServiceById
            {
                Id = carServiceId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarServiceEndpoint([FromForm] CarServiceDto carServiceDto, IFormFile File)
        {
            var command = new CreateCarService
            {
                File = File,
                Name = carServiceDto.Name,
                Description = carServiceDto.Description,
                Address = carServiceDto.Address,
                BrandsList = carServiceDto.BrandsList,
                ContainerName = AzureContainers.GetCarFlowCarServicesContainer()
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{carServiceId}")]
        public async Task<IActionResult> DeleteCar(int carServiceId)
        {
            var command = new DeleteCarService { 
                CarServiceId = carServiceId,
                ContainerName = AzureContainers.GetCarFlowCarServicesContainer()
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{carServiceId}")]
        public async Task<IActionResult> UpdateCarService(int carServiceId, [FromForm] CarServicePatchDto carServiceDto, IFormFile File)
        {
            var command = new UpdateCarService
            {
                Id = carServiceId,
                File = File,
                Name = carServiceDto.Name,
                Description = carServiceDto.Description,
                Address = carServiceDto.Address,
                BrandsList = carServiceDto.BrandsList,
                ContainerName = AzureContainers.GetCarFlowCarServicesContainer()
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
