using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IBrandRepository
    {
        Task Create(Brand obj);
        Task<List<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task Delete(Brand obj);
    }
}
