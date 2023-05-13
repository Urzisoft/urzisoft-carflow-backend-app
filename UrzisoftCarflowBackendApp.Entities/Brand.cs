namespace UrzisoftCarflowBackendApp.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string StorageImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CarServiceId { get; set; }
        public CarService CarService { get; set; }
    }
}
