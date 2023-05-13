using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IPriceRepository
    {
        Task Create(Price obj);
        Task<List<Price>> GetAll();
        Task<Price> GetById(int id);
        Task Delete(Price obj);
    }
}
