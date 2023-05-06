﻿namespace UrzisoftCarflowBackendApp.Entities
{
    public class Fuel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Quality { get; set; }
        public List<Price> Price { get; set; }
    }
}
