using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class UpdateCarHandler : IRequestHandler<UpdateCar, Car>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> Handle(UpdateCar request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetById(request.Id);

            if (car is not null)
            {
                car.Generation = request.Generation ?? car.Generation;
                car.Brand = request.Brand ?? car.Brand;
                car.Model =  request.Model ?? car.Model;    
                car.Year = request.Year ?? car.Year;
                car.GasType = request.GasType ?? car.GasType;
                car.Mileage = request.Mileage ?? car.Mileage;
                car.Gearbox = request.Gearbox ?? car.Gearbox;
                car.Power = request.Power ?? car.Power;
                car.EngineSize = request.EngineSize ?? car.EngineSize;
                car.DriveWheel = request.DriveWheel ?? car.DriveWheel;
                car.LicensePlate = request.LicensePlate ?? car.LicensePlate;

                await _unitOfWork.Save();

                return car;
            }

            return null;
        }
    }
}
