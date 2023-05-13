using System.Collections.Generic;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos

{
    public class CarServiceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public List<int> BrandsListIds { get; set; }
    }
}
