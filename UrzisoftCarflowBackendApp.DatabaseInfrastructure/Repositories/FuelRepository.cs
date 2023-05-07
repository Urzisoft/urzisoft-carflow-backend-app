using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class FuelRepository : IFuelRepository
    {
        private readonly DataContext _dataContext;

        public FuelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(Fuel obj)
        {
            await _dataContext.Fuels.AddAsync(obj);
        }

        public Task<List<Fuel>> GetAll()
        {
            return _dataContext.Fuels.Include(fuel => fuel.Price).ToListAsync();
        }

        public Task<Fuel> GetById(int id)
        {
            return _dataContext.Fuels.Include(fuel => fuel.Price).SingleOrDefaultAsync((fuel) => fuel.Id == id);
        }

        public async Task Delete(Fuel obj)
        {
            _dataContext.Fuels.Remove(obj);
        }
    }
}
