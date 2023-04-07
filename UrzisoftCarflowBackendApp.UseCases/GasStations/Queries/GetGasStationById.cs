using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.GasStations.Queries
{
    public class GetGasStationById : IRequest<GasStation>

    {
        public int Id { get; set; } 
    }
}
