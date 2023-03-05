using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarDtos
{
    public class CarDto
    {
        [Required]
        [MinLength (3)]
        public string Brand { get; set; }

        [Required]
        [MinLength (3)]
        public string Model { get; set; }
    }
}
