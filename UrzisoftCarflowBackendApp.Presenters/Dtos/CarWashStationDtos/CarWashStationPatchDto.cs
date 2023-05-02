using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarWashStationDtos
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class CarWashStationPatchDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int StandardPrice { get; set; }
        
        public int PremiumPrice { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public string Address { get; set; }
        
        public string Rank { get; set; }
        
        public bool IsSelfWash { get; set; }
    }
}
