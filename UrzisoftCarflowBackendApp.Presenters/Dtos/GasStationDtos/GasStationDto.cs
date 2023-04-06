using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos
{
    public class GasStationDto
    {
        [Required]
        public Gas Gas { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
