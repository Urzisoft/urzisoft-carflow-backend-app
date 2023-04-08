using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.Queries
{
    public class GetCarWashStationById : IRequest<CarWashStation>
    {
        public int Id { get; set; }
    }
}
