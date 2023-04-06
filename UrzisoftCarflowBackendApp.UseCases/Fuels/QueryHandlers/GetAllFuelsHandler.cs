using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Fuels.Queries;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.QueryHandlers
{
    public class GetAllFuelsHandler : IRequestHandler<GetAllFuels, List<Fuel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFuelsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Fuel>> Handle(GetAllFuels request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.FuelRepository.GetAll();
        }
    }
}
