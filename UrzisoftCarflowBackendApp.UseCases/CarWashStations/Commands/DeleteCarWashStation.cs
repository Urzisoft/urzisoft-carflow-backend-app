using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands
{
    public class DeleteCarWashStation : IRequest<CarWashStation>
    {
        public int CarWashStationId { get; set; }
        public string ContainerName { get; set; }
    }
}
