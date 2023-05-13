using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.Commands
{
    public class DeletePrice: IRequest<Price>
    {
        public int PriceId { get; set; }
    }
}
