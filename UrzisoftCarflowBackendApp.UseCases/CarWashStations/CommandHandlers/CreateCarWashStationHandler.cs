using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.CommandHandlers
{
    public class CreateCarWashStationHandler : IRequestHandler<CreateCarWashStation, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarWashStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarWashStation> Handle(CreateCarWashStation request, CancellationToken cancellationToken)
        {
            var carWashStation = new CarWashStation
            {
                Name = request.Name,
                StandardPrice = request.StandardPrice,
                PremiumPrice = request.PremiumPrice,
                City = request.City,
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
