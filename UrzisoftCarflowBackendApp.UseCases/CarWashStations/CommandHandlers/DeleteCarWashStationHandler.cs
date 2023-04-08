using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.CommandHandlers
{
    public class DeleteCarWashStationHandler : IRequestHandler<DeleteCarWashStation, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarWashStationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarWashStation> Handle(DeleteCarWashStation request, CancellationToken cancellationToken)
        {
            var carWashStation = await _unitOfWork.CarWashStationRepository.GetById(request.CarWashStationId);

            if (carWashStation is not null)
            {
                await _unitOfWork.CarWashStationRepository.Delete(carWashStation);
                await _unitOfWork.Save();

                return carWashStation;
            }

            return null;
        }
    }
}
