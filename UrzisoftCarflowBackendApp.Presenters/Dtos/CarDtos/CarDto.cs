using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    [Index(nameof(LicensePlate), IsUnique = true)]
    public class CarDto
    {
        [Required]
        public Brand Brand { get; set; }

        [Required]
        public Model Model { get; set; }

        [Required]
        public string Generation { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string GasType { get; set; }

        [Required]
        [MaxLength(999999)]
        [MinLength(1)]
        public string Mileage { get; set; }
        
        public string Gearbox { get; set; }
        public int Power { get; set; }

        public int EngineSize { get; set; }

        [Required]
        public string DriveWheel { get; set; }

        [Required]
        public string LicensePlate { get; set; }
    }
}
