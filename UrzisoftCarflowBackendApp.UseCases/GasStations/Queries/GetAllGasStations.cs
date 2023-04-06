using MediatR;
using UrzisoftCarflowBackendApp.Entities;
namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Queries
{
    public class GetAllGasStations : IRequest<List<GasStation>>
    {

    }
}
