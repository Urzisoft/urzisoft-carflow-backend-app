using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class CreateCarHandler : IRequestHandler<CreateCar, Car>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public CreateCarHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Car> Handle(CreateCar request, CancellationToken cancellationToken)
        {
            string fileName = request.Brand.Name + " " + request.Model.Name;
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var car = new Car
            {
                StorageImageUrl = CustomStorageImageUrl,
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
