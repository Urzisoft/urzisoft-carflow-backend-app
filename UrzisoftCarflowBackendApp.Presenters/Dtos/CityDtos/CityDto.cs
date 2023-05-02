using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CityDtos
{
    [Index(nameof(Name), IsUnique = true)]
    public class CityDto
    {
        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(3)]
        public string County { get; set; }
    }
}
