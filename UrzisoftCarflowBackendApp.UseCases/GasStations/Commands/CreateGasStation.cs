﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Commands
{
    public class CreateGasStation : IRequest<GasStation>
    {
        public IFormFile File { get; set; }
        public string ContainerName { get; set; }
        public string Name { get; set; }
        public Fuel Fuel { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
