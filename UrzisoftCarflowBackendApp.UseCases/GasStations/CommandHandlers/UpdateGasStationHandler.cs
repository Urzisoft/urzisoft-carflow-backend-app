using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.CommandHandlers
{
    public class UpdateGasStationHandler : IRequestHandler<UpdateGasStation, GasStation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public UpdateGasStationHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<GasStation> Handle(UpdateGasStation request, CancellationToken cancellationToken)
        {
            var gasStation = await _unitOfWork.GasStationRepository.GetById(request.Id);
            var validateGasStationName = request.Name ?? gasStation.Name;
            var validateGasStationAddress = request.Address ?? request.Address;
            var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnTwoValues(validateGasStationName, validateGasStationAddress);
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            if (gasStation is not null)
            {
                gasStation.StorageImageUrl = CustomStorageImageUrl ?? gasStation.StorageImageUrl;
                gasStation.Name = request.Name ?? gasStation.Name;
                gasStation.FuelId = request.FuelId ?? gasStation.FuelId;
                gasStation.CityId = request.CityId ?? gasStation.CityId;
                gasStation.Address = request.Address ?? gasStation.Address;
                gasStation.Rank = request.Rank ?? gasStation.Rank;

                await _unitOfWork.Save();

                return gasStation;
            }

            return null;
        }
    }
}
