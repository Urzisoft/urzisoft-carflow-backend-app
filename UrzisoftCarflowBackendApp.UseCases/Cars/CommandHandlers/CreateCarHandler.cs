using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

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
            var brand = await _unitOfWork.BrandRepository.GetById(request.BrandId);
            var model = await _unitOfWork.ModelRepository.GetById(request.ModelId);
            var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnThreeValues(brand.Name, model.Name, request.LicensePlate);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var car = new Car
            {
                StorageImageUrl = CustomStorageImageUrl,
                ModelId = request.ModelId,
                BrandId = request.BrandId,
                Generation = request.Generation,
                Year = request.Year,
                GasType = request.GasType,
                Mileage = request.Mileage, 
                Gearbox = request.Gearbox,
                Power = request.Power,
                EngineSize = request.EngineSize,
                DriveWheel = request.DriveWheel,
                LicensePlate = request.LicensePlate,
                Username = request.Username,
            };

            await _unitOfWork.CarRepository.Create(car);
            await _unitOfWork.Save();

            return car;
        }
    }
}
