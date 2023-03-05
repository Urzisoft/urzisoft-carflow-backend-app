using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Commands
{
    public class CreateCar : IRequest<Car>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
