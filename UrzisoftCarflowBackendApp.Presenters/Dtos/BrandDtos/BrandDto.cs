﻿using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.BrandDtos
{
    public class BrandDto
    {
        [Required]
        public string Name { get; set; }

        [MinLength(1)]
        public string Description { get; set; }
    }
}
