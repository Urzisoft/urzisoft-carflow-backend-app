﻿using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Commands
{
    public class UpdateGasStation : IRequest<GasStation>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Fuel Fuel { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
