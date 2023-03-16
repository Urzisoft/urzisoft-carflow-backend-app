namespace UrzisoftCarflowBackendApp.Entities
{
    public class CarWashStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StandardPrice { get; set; }
        public int PremiumPrice { get; set; }
        public City Location { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
        public bool IsSelfWash { get; set; }
    }
}
