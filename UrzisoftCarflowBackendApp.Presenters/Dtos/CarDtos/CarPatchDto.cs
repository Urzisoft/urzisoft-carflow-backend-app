using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    [Index(nameof(LicensePlate), IsUnique = true)]
    public class CarPatchDto
    {
        public Brand Brand { get; set; }

        public Model Model { get; set; }

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
