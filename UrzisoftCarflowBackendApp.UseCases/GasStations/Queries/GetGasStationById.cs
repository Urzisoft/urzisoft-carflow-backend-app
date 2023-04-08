using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Queries
{
    public class GetGasStationById : IRequest<GasStation>

    {
        public int Id { get; set; } 
    }
}
