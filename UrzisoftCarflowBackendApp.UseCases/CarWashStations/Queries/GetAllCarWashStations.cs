using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.Queries
{
    public class GetAllCarWashStations : IRequest<List<CarWashStation>>
    {
    }
}
