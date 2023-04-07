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
        public Fuel Fuel { get; set; }
        public City City { get; set; }
        
    }
}
