namespace UrzisoftCarflowBackendApp.Entities
{
    public class GasStation
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public string Name { get; set; }
        public Fuel Fuel { get; set; }   
        public City City { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
