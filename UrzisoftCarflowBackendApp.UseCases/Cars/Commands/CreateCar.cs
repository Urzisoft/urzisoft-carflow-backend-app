﻿using MediatR;
using Microsoft.AspNetCore.Http;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Commands
{
    public class CreateCar : IRequest<Car>
    {
        public IFormFile File { get; set; }
        public string Username { get; set; }
        public string ContainerName { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string Generation { get; set; }
        public int Year { get; set; }
        public string GasType { get; set; }
        public string Mileage { get; set; }
        public string Gearbox { get; set; }
        public int Power { get; set; }
        public int EngineSize { get; set; }
        public string DriveWheel { get; set; }
        public string LicensePlate { get; set; }

    }
}
