﻿using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos

{
    public class CarServiceDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MinLength(1)]
        public Brand[] BrandsList { get; set; }
    }
}
