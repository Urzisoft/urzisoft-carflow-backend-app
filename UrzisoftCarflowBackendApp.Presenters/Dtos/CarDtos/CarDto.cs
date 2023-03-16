using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    public class CarDto
    {
        [Required]
        public Brand Brand { get; set; }

        [Required]
        public Model Model { get; set; }

        [Required]
        public string Generation { get; set; }

        [Required]
        [StringLength(4)]
        public string Year { get; set; }

        [Required]
        public string GasType { get; set; }

        [Required]
        [MaxLength(999999)]
        [MinLength(1)]
        public string Mileage { get; set; }
        
        public string Gearbox { get; set; }

        [MaxLength(4)]
        public int EngineSize { get; set; }

        [Required]
        public string DriveWheel { get; set; }

        [Required]
        [StringLength(7)]
        public string LicensePlate { get; set; }
    }
}
