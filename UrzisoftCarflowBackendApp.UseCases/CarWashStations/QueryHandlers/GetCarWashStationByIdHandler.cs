using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.QueryHandlers
{
    public class GetCarWashStationByIdHandler : IRequestHandler<GetCarWashStationById, CarWashStation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarWashStationByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarWashStation> Handle(GetCarWashStationById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CarWashStationRepository.GetById(request.Id);
        }
    }
}
