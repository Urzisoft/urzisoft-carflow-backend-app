using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.FuelDtos
{
    public class FuelPatchDto
    {
        public string Name { get; set; }

        [MaxLength(999999)]
        [MinLength(1)]
        public string Description { get; set; }

        public string Type { get; set; }

        public string Quality { get; set; }

        public double Price { get; set; }
    }
}

