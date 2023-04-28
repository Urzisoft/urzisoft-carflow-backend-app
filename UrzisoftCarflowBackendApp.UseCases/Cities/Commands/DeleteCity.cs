using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.Commands
{
    public class DeleteCity : IRequest<City>
    {
        public int CityId { get; set; }
        public string ContainerName { get; set; }
    }
}
