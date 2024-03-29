﻿namespace UrzisoftCarflowBackendApp.Entities
{
    public class CarService
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Brand MainBrand { get; set; }
        public int MainBrandId { get; set; }
        public City CarServiceCity { get; set; }  
        public int CarServiceCityId { get; set; } 
    }
}
