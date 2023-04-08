using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos
{
    public class GasStationPatchDto
    {
        public Fuel Fuel { get; set; }
        
        public City City { get; set; }
    }
}
