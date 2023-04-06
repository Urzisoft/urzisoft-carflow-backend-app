using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IModelRepository
    {
        Task Create(Model obj);
        Task<List<Model>> GetAll();
        Task<Model> GetById(int id);
        Task Delete(Model obj);
    }
}
