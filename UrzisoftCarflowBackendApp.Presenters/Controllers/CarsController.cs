using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Cars.Queries;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/cars")]
    [ApiController]
    [Authorize(Policy = "ActivePolicy")]

    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarsEndpoint()
        {
            var query = new GetAllCars();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{carId}")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            var query = new GetCarById
            {
                Id = carId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarEndpoint([FromForm] CarDto carDto, IFormFile File)
        {
            var command = new CreateCar
            {
                File = File,
                BrandId = carDto.BrandId,
                ModelId = carDto.ModelId,
                Generation = carDto.Generation,
                Year = carDto.Year,
                GasType = carDto.GasType,
                Mileage = carDto.Mileage,
                Gearbox = carDto.Gearbox,
                Power = carDto.Power,
                EngineSize = carDto.EngineSize,
                DriveWheel = carDto.DriveWheel,
                LicensePlate = carDto.LicensePlate,
                Username = carDto.Username,
                ContainerName = AzureContainers.GetCarFlowCarsContainer(),
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{carId}")]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            var command = new DeleteCar{ 
                CarId = carId,
                ContainerName = AzureContainers.GetCarFlowCarsContainer(),
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{carId}")]
        public async Task<IActionResult> UpdateCar(int carId, [FromForm] CarPatchDto carDto, IFormFile File)
        {
            var command = new UpdateCar
            {
                Id = carId,
                File = File,
                BrandId = carDto.BrandId,
                ModelId = carDto.ModelId,
                Generation = carDto.Generation,
                Year = carDto.Year,
                GasType = carDto.GasType,
                Mileage = carDto.Mileage,
                Gearbox = carDto.Gearbox,
                Power = carDto.Power,
                EngineSize = carDto.EngineSize,
                DriveWheel = carDto.DriveWheel,
                LicensePlate = carDto.LicensePlate,
                ContainerName = AzureContainers.GetCarFlowCarsContainer(),
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
