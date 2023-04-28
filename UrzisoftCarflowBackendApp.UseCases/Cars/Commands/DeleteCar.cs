using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Commands
{
    public class DeleteCar : IRequest<Car>
    {
        public int CarId { get; set; }
        public string ContainerName { get; set; }
    }
}
