using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Prices.Queries
{
    public class GetAllPrices : IRequest<List<Price>>
    {
    }
}
