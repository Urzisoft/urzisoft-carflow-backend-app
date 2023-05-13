using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    public class CarDto
    {
        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public string Generation { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string GasType { get; set; }

        [Required]
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
