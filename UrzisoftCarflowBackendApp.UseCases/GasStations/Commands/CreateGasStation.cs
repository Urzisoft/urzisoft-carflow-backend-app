using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Commands
{
    public class CreateGasStation : IRequest<GasStation>
    {
        public Gas Gas { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
    }
}
