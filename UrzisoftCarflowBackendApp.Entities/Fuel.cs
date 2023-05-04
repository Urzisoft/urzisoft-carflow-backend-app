using Microsoft.EntityFrameworkCore;

namespace UrzisoftCarflowBackendApp.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class Fuel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Quality { get; set; }
        public double Price { get; set; }
    }
}
