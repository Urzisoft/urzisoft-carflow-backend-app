using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarWashStationDtos
{
    public class CarWashStationPatchDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int StandardPrice { get; set; }
        
        public int PremiumPrice { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Address { get; set; }
        
        public string Rank { get; set; }
        
        public bool IsSelfWash { get; set; }
    }
}
