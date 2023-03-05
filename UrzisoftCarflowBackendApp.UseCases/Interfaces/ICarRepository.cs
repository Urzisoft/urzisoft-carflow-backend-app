using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface ICarRepository
    {
        Task Create(Car obj);
        Task<Car> GetById(int id);
        Task<List<Car>> GetAll();
    }
}
