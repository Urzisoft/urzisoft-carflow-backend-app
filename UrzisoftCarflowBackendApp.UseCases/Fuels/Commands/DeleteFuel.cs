using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.Commands
{
    public class DeleteFuel : IRequest<Fuel>
    {
        public int FuelId { get; set; }
    }
}
