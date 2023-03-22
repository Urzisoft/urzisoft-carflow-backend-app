using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface ICarRepository
    {
        Task Create(Car obj);
        Task<List<Car>> GetAll();
        Task<Car> GetById(int id);
        Task Delete(Car obj);
    }
}
