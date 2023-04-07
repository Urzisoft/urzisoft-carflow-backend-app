using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Cars.Commands;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.CommandHandlers
{
    internal class CreateGasStationHandler : IRequestHandler<CreateGasStation, GasStation>
    {
        public readonly IUnitOfWork _unitOfWork;

        public CreateGasStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GasStation> Handle(CreateGasStation request, CancellationToken cancellationToken)
        {
            var gasStation = new GasStation
            {
                Fuel = request.Fuel,
                City = request.City

            };

            await _unitOfWork.GasStationRepository.Create(gasStation);
            await _unitOfWork.Save();

            return gasStation;
        }


    }
}
