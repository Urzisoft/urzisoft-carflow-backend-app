using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos
{
    public class ModelDto
    {
        [Required]
        public string Name { get; set; }
    }
}
