using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Prices.Commands;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.CommandsHandlers
{
    public class DeletePriceHandler : IRequestHandler<DeletePrice, Price>
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public DeletePriceHandler(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }


        public async Task<Price> Handle(DeletePrice request, CancellationToken cancellationToken)
        {
            var price = await _unitOfWOrk.PriceRepository.GetById(request.PriceId);

            if (price is not null)
            {
                await _unitOfWOrk.PriceRepository.Delete(price);
                await _unitOfWOrk.Save();

                return price;
            }

            return null;
        }
    }
}
