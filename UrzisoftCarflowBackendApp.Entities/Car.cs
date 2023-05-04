using Microsoft.EntityFrameworkCore;

namespace UrzisoftCarflowBackendApp.Entities
{
    [Index(nameof(LicensePlate), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class Car
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public string Generation { get; set; }
        public int Year { get; set; }
        public string GasType { get; set; }
        public string Mileage { get; set; }
        public string Gearbox { get; set; }
        public int Power { get; set; }
        public int EngineSize { get; set; }
        public string DriveWheel { get; set; }
        public string LicensePlate { get; set; }
    }
}