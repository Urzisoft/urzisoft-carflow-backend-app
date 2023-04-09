using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.Commands
{
    public class DeleteCarService : IRequest<CarService>
    {
        public int CarServiceId { get; set; }
    }
}
