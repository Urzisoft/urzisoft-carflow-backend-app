using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface ICarWashStationRepository
    {
        Task Create(CarWashStation obj);
        Task<List<CarWashStation>> GetAll();
        Task<CarWashStation> GetById(int id);
        Task Delete(CarWashStation obj);
    }
}
