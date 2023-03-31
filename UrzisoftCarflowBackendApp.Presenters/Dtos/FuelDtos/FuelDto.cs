using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.FuelDtos
{
    public class FuelDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(999999)]
        [MinLength(1)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Quality { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
