using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class CreateCarHandler : IRequestHandler<CreateCar, Car>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> Handle(CreateCar request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                Model = request.Model,
                Brand = request.Brand,
                Generation = request.Generation,
                Year = request.Year,
                GasType = request.GasType,
                Mileage = request.Mileage, 
                Gearbox = request.Gearbox,
                Power = request.Power,
                EngineSize = request.EngineSize,
                DriveWheel = request.DriveWheel,
                LicensePlate = request.LicensePlate,
            };

            await _unitOfWork.CarRepository.Create(car);
            await _unitOfWork.Save();

            return car;
        }
    }
}
