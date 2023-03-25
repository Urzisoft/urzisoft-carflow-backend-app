using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface ICityRepository
    {
        Task Create(City obj);
        Task<List<City>> GetAll();
        Task<City> GetById(int id);
        Task Delete(City obj);
    }
}

