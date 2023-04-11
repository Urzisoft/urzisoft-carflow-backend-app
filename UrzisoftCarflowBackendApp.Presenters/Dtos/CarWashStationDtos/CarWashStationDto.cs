using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarWashStationDtos
{
    public class CarWashStationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int StandardPrice { get; set; }
        
        public int PremiumPrice { get; set; }

        [Required]
        public City Location { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        public string Rank { get; set; }

        [Required]
        public bool IsSelfWash { get; set; }
    }
}
