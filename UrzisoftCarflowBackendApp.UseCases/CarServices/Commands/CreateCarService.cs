using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.Commands
{
    public class CreateCarService : IRequest<CarService>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Brand> BrandsList { get; set; }

    }
}
