using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface ICarServiceRepository
    {
        Task Create(CarService obj);
        Task<List<CarService>> GetAll();
        Task<CarService> GetById(int id);
        Task Delete(CarService obj);
    }
}
