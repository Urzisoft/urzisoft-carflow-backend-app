using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IGasStationRepository
    {
        Task Create(GasStation obj);
        Task<List<GasStation>> GetAll();
        Task<GasStation> GetById(int id);
        Task Delete(GasStation obj);
    }
}

