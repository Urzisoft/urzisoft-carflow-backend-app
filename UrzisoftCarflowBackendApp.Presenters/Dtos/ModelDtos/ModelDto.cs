using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos
{
    public class ModelDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
