using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.CommandHandlers
{
    public class UpdateCarWashStationHandler : IRequestHandler<UpdateCarWashStation, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarWashStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarWashStation> Handle(UpdateCarWashStation request, CancellationToken cancellationToken)
        {
            var carWashStation = await _unitOfWork.CarWashStationRepository.GetById(request.Id);

            if (carWashStation is not null)
            {
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
