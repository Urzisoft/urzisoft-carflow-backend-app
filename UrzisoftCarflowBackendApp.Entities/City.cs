using Microsoft.EntityFrameworkCore;

namespace UrzisoftCarflowBackendApp.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class City
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public string Name { get; set; }
        public string County { get; set; }
    }
}
