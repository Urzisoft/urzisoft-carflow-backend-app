using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.BrandDtos
{
    public class BrandPatchDto
    {
        public string Name { get; set; }

        [MinLength(1)]
        public string Description { get; set; }
    }
}
