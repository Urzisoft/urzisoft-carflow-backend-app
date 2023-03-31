using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.Commands
{
    public class CreateCity : IRequest<City>
    {
        public string Name { get; set; }
        public string County { get; set; }
    }
}
