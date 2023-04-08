using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Commands
{
    public class DeleteGasStation : IRequest<GasStation>
    {
        public int GasStationId { get; set; }  
    }
}
