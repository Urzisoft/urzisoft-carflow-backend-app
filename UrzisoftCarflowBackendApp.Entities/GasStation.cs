using Microsoft.EntityFrameworkCore;

namespace UrzisoftCarflowBackendApp.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class GasStation
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public string Name { get; set; }
        public Fuel Fuel { get; set; }   
        public City City { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
