using Microsoft.EntityFrameworkCore;

namespace UrzisoftCarflowBackendApp.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class Model
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
