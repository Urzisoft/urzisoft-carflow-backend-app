using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    public class CarDto
    {
        [Required]
        public Brand Brand { get; set; }

        [Required]
        public Model Model { get; set; }
        
    }
}
