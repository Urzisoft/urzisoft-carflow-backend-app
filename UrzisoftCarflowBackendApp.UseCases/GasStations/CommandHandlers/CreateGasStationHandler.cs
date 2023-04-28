using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.CommandHandlers
{
    internal class CreateGasStationHandler : IRequestHandler<CreateGasStation, GasStation>
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public CreateGasStationHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
        }

        public async Task<GasStation> Handle(CreateGasStation request, CancellationToken cancellationToken)
        {

            var fileName = request.Name + "-" + request.Address;
            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);

            var gasStation = new GasStation
            {
                StorageImageUrl = CustomStorageImageUrl,
                Name = request.Name,
                Fuel = request.Fuel,
                City = request.City,
                Address = request.Address,
                Rank = request.Rank
            };

            await _unitOfWork.GasStationRepository.Create(gasStation);
            await _unitOfWork.Save();

            return gasStation;
        }
    }
}
