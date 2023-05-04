using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos
{
    public class GasStationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Fuel Fuel { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Rank { get; set; }
    }
}
