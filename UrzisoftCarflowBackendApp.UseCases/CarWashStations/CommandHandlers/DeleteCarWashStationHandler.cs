using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.CommandHandlers
{
    public class DeleteCarWashStationHandler : IRequestHandler<DeleteCarWashStation, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public DeleteCarWashStationHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService; 
        }

        public async Task<CarWashStation> Handle(DeleteCarWashStation request, CancellationToken cancellationToken)
        {
            var carWashStation = await _unitOfWork.CarWashStationRepository.GetById(request.CarWashStationId);

            if (carWashStation is not null)
            {
                string fileName = carWashStation.Name + "-" + carWashStation.Address;

                await _imageStorageService.DeleteImage(fileName, request.ContainerName);
                await _unitOfWork.CarWashStationRepository.Delete(carWashStation);
                await _unitOfWork.Save();

                return carWashStation;
            }

            return null;
        }
    }
}
