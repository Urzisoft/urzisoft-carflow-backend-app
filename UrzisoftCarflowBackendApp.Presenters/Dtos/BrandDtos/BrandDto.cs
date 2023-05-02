using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.BrandDtos
{
    [Index(nameof(Name), IsUnique = true)]
    public class BrandDto
    {
        [Required]
        public string Name { get; set; }

        [MinLength(1)]
        public string Description { get; set; }
    }
}
