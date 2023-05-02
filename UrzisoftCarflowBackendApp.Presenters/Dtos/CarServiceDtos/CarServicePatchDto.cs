using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class CarServicePatchDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
       
        public string Description { get; set; }
        
        public string Address { get; set; }
        
        public List<Brand> BrandsList { get; set; }
    }
}
