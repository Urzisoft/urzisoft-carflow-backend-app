using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CityDtos
{
    public class CityDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string County { get; set; }
    }
}
