﻿using MediatR;
using Microsoft.AspNetCore.Http;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands
{
    public class UpdateCarWashStation : IRequest<CarWashStation>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
        public string Name { get; set; }
        public int? StandardPrice { get; set; }
        public int? PremiumPrice { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
        public bool? IsSelfWash { get; set; }
    }
}
