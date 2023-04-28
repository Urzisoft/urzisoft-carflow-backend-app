using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

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

            var fileName = validateGasStationName + "-" + validateGasStationAddress;
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            if (gasStation is not null)
            {
                gasStation.StorageImageUrl = CustomStorageImageUrl ?? gasStation.StorageImageUrl;
                gasStation.Name = request.Name ?? gasStation.Name;
                gasStation.Fuel = request.Fuel ?? gasStation.Fuel;
                gasStation.City = request.City ?? gasStation.City;
                gasStation.Address = request.Address ?? gasStation.Address;
                gasStation.Rank = request.Rank ?? gasStation.Rank;

                await _unitOfWork.Save();

                return gasStation;
            }

            return null;
        }
    }
}
