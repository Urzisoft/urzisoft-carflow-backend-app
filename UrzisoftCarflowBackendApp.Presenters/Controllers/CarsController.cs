using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Cars.Queries;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/cars")]
    [ApiController]
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
        public async Task<IActionResult> CreateCarEndpoint([FromBody] CarDto carDto)
        {
            var command = new CreateCar
            {
                Brand = carDto.Brand,
                Model = carDto.Model,
                Generation = carDto.Generation,
                Year = carDto.Year,
                GasType = carDto.GasType,
                Mileage = carDto.Mileage,
                Gearbox = carDto.Gearbox,
                Power = carDto.Power,
                EngineSize = carDto.EngineSize,
                DriveWheel = carDto.DriveWheel,
                LicensePlate = carDto.LicensePlate,

            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{carId}")]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            var command = new DeleteCar{ CarId = carId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("{carId}")]
        public async Task<IActionResult> UpdateCar(int carId, [FromBody] CarPatchDto carDto)
        {
            var command = new UpdateCar
            {
                Id = carId,
                Generation = carDto.Generation,
                Year = carDto.Year,
                GasType = carDto.GasType,
                Mileage = carDto.Mileage,
                Gearbox = carDto.Gearbox,
                Power = carDto.Power,
                EngineSize = carDto.EngineSize,
                DriveWheel = carDto.DriveWheel,
                LicensePlate = carDto.LicensePlate
            };

            var result = await _mediator.Send(command);

            return result is null ? NotFound() : NoContent();
        }
    }
}
