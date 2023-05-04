using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CityDtos
{
    public class CityPatchDto
    {
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [MaxLength(100)]
        [MinLength(1)]
        public string County { get; set; }
    }
}
