using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Fuels.Queries
{
    public class GetFuelById : IRequest<Fuel>
    {
        public int Id { get; set; }
    }
}
