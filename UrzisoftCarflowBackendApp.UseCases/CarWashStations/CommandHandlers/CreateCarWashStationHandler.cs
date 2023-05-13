using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.CommandHandlers
{
    public class CreateCarWashStationHandler : IRequestHandler<CreateCarWashStation, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public CreateCarWashStationHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<CarWashStation> Handle(CreateCarWashStation request, CancellationToken cancellationToken)
        {
            var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnTwoValues(request.Name, request.Address);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var carWashStation = new CarWashStation
            {
                StorageImageUrl = CustomStorageImageUrl,
                Name = request.Name,
                StandardPrice = request.StandardPrice,
                PremiumPrice = request.PremiumPrice,
                CityId = request.CityId,
                Address = request.Address,
                Rank = request.Rank,
                IsSelfWash = request.IsSelfWash,
            };

            await _unitOfWork.CarWashStationRepository.Create(carWashStation);
            await _unitOfWork.Save();

            return carWashStation;
        }
    }
}
