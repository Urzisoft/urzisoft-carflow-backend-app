using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Prices.Queries;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.QueryHandlers
{
    public class GetPriceByIdHandler : IRequestHandler<GetPriceById, Price>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPriceByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Price> Handle(GetPriceById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PriceRepository.GetById(request.Id);
        }
    }
}
