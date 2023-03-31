using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.Queries
{
    public class GetAllFuels : IRequest<List<Fuel>>
    {
    }
}
