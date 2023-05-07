using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.FuelDtos
{
    public class FuelDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Quality { get; set; }

        [Required]
        public List<Price> Price { get; set; }
    }
}
