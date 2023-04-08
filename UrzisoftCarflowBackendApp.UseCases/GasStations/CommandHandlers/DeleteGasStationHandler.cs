using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.GasStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.CommandHandlers
{
    public class DeleteGasStationHandler : IRequestHandler<DeleteGasStation, GasStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGasStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GasStation> Handle(DeleteGasStation request, CancellationToken cancellationToken)
        {
            var gasStation = await _unitOfWork.GasStationRepository.GetById(request.GasStationId);

            if (gasStation is not null)
            {
                await _unitOfWork.GasStationRepository.Delete(gasStation);
                await _unitOfWork.Save();

                return gasStation;
            }

            return null;
        }
    }
}
