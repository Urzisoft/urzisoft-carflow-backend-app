using MediatR;
using Microsoft.AspNetCore.Http;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Commands
{
    public class UpdateGasStation : IRequest<GasStation>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
        public string Name { get; set; }
        public int? FuelId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
