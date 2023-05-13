namespace UrzisoftCarflowBackendApp.Presenters.Dtos.CarServiceDtos
{
    public class CarServicePatchDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Description { get; set; }

        public string Address { get; set; }

        public int MainBrandId { get; set; }
    }
}
