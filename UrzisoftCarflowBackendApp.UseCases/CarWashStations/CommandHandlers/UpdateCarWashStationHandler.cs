using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.CommandHandlers
{
    public class UpdateCarWashStationHandler : IRequestHandler<UpdateCarWashStation, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorageService;

        public UpdateCarWashStationHandler(IUnitOfWork unitOfWork, IImageStorageService imageStorageService)
        {
            _unitOfWork = unitOfWork;
            _imageStorageService = imageStorageService;
          _imageStorageService = imageStorageService;
        }

        public async Task<CarWashStation> Handle(UpdateCarWashStation request, CancellationToken cancellationToken)
        {
            var carWashStation = await _unitOfWork.CarWashStationRepository.GetById(request.Id);
            string validName = request.Name ?? carWashStation.Name;
            string validAddress = request.Address ?? carWashStation.Address;
            string fileName = validName + "-" + validAddress;

            var CustomStorageImageUrl = await _imageStorageService.UploadImage(fileName, request.File, request.ContainerName);


            if (carWashStation is not null)
            {
                carWashStation.StorageImageUrl = CustomStorageImageUrl ?? carWashStation.StorageImageUrl;
                carWashStation.Name = request.Name ?? carWashStation.Name;
                carWashStation.StandardPrice = request.StandardPrice ?? carWashStation.StandardPrice;
                carWashStation.PremiumPrice = request.PremiumPrice ?? carWashStation.PremiumPrice;
                carWashStation.City = request.City ?? carWashStation.City;
                carWashStation.Address = request.Address ?? carWashStation.Address;
                carWashStation.Rank = request.Rank ?? carWashStation.Rank;
                carWashStation.IsSelfWash = request.IsSelfWash ?? carWashStation.IsSelfWash;

                await _unitOfWork.Save();

                return carWashStation;
            }

            return null;
        }
    }
}
