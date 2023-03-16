namespace UrzisoftCarflowBackendApp.Entities
{
    public class GasStations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gas Gas { get; set; }   
        public City Location { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
