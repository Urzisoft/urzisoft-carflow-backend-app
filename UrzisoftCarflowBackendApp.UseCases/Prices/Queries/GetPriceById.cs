using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.Queries
{
    public class GetPriceById : IRequest<Price>
    {
        public int Id { get; set; }
    }
}
