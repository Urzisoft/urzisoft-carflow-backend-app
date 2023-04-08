using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarWashStations.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.QueryHandlers
{
    public class GetAllCarWashStationsHandler : IRequestHandler<GetAllCarWashStations, List<CarWashStation>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarWashStationsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarWashStation>> Handle(GetAllCarWashStations request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CarWashStationRepository.GetAll();
        }
    }
}
