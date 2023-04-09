using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.CarServices.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.QueryHandlers
{
    public class GetAllCarServicesHandler : IRequestHandler<GetAllCarServices, List<CarService>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarServicesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarService>> Handle(GetAllCarServices request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CarServiceRepository.GetAll();
        }
    }
}
