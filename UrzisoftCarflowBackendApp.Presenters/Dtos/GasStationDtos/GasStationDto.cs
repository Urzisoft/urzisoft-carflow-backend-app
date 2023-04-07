using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos
{
    public class GasStationDto
    {
        [Required]
        public Fuel Fuel { get; set; }
        [Required]
        public City City { get; set; }  



    }
}
