using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Prices.Queries;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.QueryHandlers
{
    public class GetAllPricesHandler : IRequestHandler<GetAllPrices, List<Price>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPricesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Price>> Handle(GetAllPrices request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PriceRepository.GetAll();
        }
    }
}
