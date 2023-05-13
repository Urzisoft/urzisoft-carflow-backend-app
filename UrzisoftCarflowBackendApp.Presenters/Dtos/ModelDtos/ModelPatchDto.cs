using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos
{
    public class ModelPatchDto
    {
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
