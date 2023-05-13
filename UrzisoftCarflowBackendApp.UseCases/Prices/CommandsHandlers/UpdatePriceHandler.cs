using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Prices.Commands;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.CommandsHandlers
{
    public class UpdatePriceHandler : IRequestHandler<UpdatePrice, Price>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePriceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Price> Handle(UpdatePrice request, CancellationToken cancellationToken)
        {
            var price = await _unitOfWork.PriceRepository.GetById(request.Id);

            if (price is not null)
            {
                price.Value = request.Value ?? price.Value;
                price.Fuel = request.Fuel ?? price.Fuel;
                price.Date = request.Date ?? price.Date;

                await _unitOfWork.Save();

                return price;
            }

            return null;
        }
    }
}
