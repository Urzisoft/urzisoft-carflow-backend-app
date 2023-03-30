using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.BrandDtos
{
    public class BrandDto
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(999999)]
        [MinLength(1)]
        public string Description { get; set; }
    }
}
