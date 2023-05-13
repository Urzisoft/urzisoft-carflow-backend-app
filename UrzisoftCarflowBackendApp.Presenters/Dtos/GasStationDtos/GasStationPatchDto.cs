using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.GasStationDtos
{
    public class GasStationPatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FuelId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
    }
}
