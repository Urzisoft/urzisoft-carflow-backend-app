using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Commands
{
    public class CreateCar : IRequest<Car>
    {
        public Brand Brand { get; set; }
        public Model Model { get; set; }
    }
}
