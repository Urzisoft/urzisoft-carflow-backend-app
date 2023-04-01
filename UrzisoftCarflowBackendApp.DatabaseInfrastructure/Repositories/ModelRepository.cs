using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class ModelRepository : IModelRepository
    {

        private readonly DataContext _dataContext;

        public ModelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(Model obj)
        {
            await _dataContext.Models.AddAsync(obj);
        }

        public Task<List<Model>> GetAll()
        {
            return _dataContext.Models.ToListAsync();
        }

        public Task<Model> GetById(int id)
        {
            return _dataContext.Models.SingleOrDefaultAsync((model) => model.Id == id);
        }

        public async Task Delete(Model obj)
        {
            _dataContext.Models.Remove(obj);
        }
    }
}
