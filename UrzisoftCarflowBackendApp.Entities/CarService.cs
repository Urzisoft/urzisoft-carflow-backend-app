﻿namespace UrzisoftCarflowBackendApp.Entities
{
    public class CarService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Brand[] BrandsList { get; set; }

    }
}
