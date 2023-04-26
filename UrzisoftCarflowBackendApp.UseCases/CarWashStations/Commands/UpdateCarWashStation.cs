﻿using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarWashStations.Commands
{
    public class UpdateCarWashStation : IRequest<CarWashStation>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StandardPrice { get; set; }
        public int? PremiumPrice { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
        public bool? IsSelfWash { get; set; }
    }
}