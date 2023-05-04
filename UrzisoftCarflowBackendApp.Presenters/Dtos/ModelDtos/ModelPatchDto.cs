using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.ModelDtos
{
    public class ModelPatchDto
    {
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }
    }
}
