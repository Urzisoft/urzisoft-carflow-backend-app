using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.CommandHandlers
{
    public class UpdateCarHandler : IRequestHandler<UpdateCar, Car>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public UpdateCarHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<Car> Handle(UpdateCar request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetById(request.Id);
            var brand = await _unitOfWork.BrandRepository.GetById(car.BrandId);
            var model = await _unitOfWork.ModelRepository.GetById(car.ModelId);

            var validBrandName = brand?.Name ?? car.Brand.Name;
            var validModelName = model?.Name ?? car.Model.Name;
            var validLicensePlate = request.LicensePlate ?? car.LicensePlate;

            var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnThreeValues(validBrandName, validModelName, validLicensePlate);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            if (car is not null)
            {
                car.StorageImageUrl = CustomStorageImageUrl ?? car.StorageImageUrl;
                car.Generation = request.Generation ?? car.Generation;
                car.BrandId = request.BrandId ?? car.BrandId;
                car.ModelId =  request.ModelId ?? car.ModelId;    
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
