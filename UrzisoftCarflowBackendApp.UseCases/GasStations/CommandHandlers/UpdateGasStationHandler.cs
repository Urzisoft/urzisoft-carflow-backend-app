using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.CommandHandlers
{
    public class UpdateGasStationHandler : IRequestHandler<UpdateGasStation, GasStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGasStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GasStation> Handle(UpdateGasStation request, CancellationToken cancellationToken)
        {
            var gasStation = await _unitOfWork.GasStationRepository.GetById(request.Id);

            if (gasStation is not null)
            {
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
