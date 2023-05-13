using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos
{
    public class CarServicePatchDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
       
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
