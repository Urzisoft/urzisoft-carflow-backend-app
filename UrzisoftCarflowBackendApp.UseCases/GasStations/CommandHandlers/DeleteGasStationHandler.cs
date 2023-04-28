using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Utils;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.CommandHandlers
{
    public class DeleteGasStationHandler : IRequestHandler<DeleteGasStation, GasStation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public DeleteGasStationHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService; 
        }

        public async Task<GasStation> Handle(DeleteGasStation request, CancellationToken cancellationToken)
        {
            var gasStation = await _unitOfWork.GasStationRepository.GetById(request.GasStationId);

            if (gasStation is not null)
            {
                var fileName = AzureBlobFileNameBuilder.GetFileNameBasedOnTwoValues(gasStation.Name, gasStation.Address);

                await _imageStorageService.DeleteImage(fileName, request.ContainerName);
                await _unitOfWork.GasStationRepository.Delete(gasStation);
                await _unitOfWork.Save();

                return gasStation;
            }

            return null;
        }
    }
}
