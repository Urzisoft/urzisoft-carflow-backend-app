using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.FuelDtos
{
    [Index(nameof(Name), IsUnique = true)]
    public class FuelPatchDto
    {
        public string Name { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        public string Type { get; set; }

        public string Quality { get; set; }

        public double Price { get; set; }
    }
}

