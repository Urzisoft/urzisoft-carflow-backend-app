using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos

{
    public class CarServiceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public List<int> BrandsIds { get; set; }
    }
}
