using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IFuelRepository
    {
        Task Create(Fuel obj);
        Task<List<Fuel>> GetAll();
        Task<Fuel> GetById(int id);
        Task Delete(Fuel obj);
    }
}