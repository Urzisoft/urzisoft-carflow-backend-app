using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
using UrzisoftCarflowBackendApp.UseCases.Prices.Commands;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.CommandsHandlers
{
    public class CreatePriceHandler : IRequestHandler<CreatePrice, Price>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreatePriceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Price> Handle(CreatePrice request, CancellationToken cancellationToken)
        {
            var price = new Price
            {
                Value = request.Value,
                Fuel = request.Fuel,
                Date = request.Date,
            };

            await _unitOfWork.PriceRepository.Create(price);
            await _unitOfWork.Save();

            return price;
        }
    }
}
