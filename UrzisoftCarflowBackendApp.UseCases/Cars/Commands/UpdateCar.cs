using MediatR;
using Microsoft.AspNetCore.Http;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Commands
{
    public class UpdateCar : IRequest<Car>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public string Generation { get; set; }
        public int? Year { get; set; }
        public string GasType { get; set; }
        public string Mileage { get; set; }
        public string Gearbox { get; set; }
        public int? Power { get; set; }
        public int? EngineSize { get; set; }
        public string DriveWheel { get; set; }
        public string LicensePlate { get; set; }
    }
}
