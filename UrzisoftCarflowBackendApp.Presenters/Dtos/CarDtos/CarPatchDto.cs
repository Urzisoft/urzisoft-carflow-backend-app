using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    public class CarPatchDto
    {
        public string Generation { get; set; }

        public int Year { get; set; }

        public string GasType { get; set; }

        [MaxLength(999999)]
        [MinLength(1)]
        public string Mileage { get; set; }

        public string Gearbox { get; set; }
        public int Power { get; set; }

        public int EngineSize { get; set; }

        public string DriveWheel { get; set; }

        public string LicensePlate { get; set; }
    }
}
