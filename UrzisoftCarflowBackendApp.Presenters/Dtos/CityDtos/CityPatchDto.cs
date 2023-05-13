using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CityDtos
{
    public class CityPatchDto
    {
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string County { get; set; }
    }
}
