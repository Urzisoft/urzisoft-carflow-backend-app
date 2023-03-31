using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.Commands
{
    public class UpdateCity : IRequest<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string County { get; set; }
    }
}
