using MediatR;
using Microsoft.AspNetCore.Http;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.Commands
{
    public class UpdateCarService : IRequest<CarService>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int? MainBrandId { get; set; }
        public int? CarServiceCityId { get; set; }
    }
}
