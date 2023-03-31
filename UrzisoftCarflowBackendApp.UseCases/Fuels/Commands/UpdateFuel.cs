using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.Commands
{
    public class UpdateFuel : IRequest<Fuel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Quality { get; set; }
        public double? Price { get; set; }
    }
}
