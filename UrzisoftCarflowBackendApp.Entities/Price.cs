namespace UrzisoftCarflowBackendApp.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
    }
}
