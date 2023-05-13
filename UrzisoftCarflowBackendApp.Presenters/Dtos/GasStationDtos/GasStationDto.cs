using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos
{
    public class GasStationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int FuelId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Rank { get; set; }
    }
}
