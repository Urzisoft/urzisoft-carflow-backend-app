using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {

        private readonly DataContext _dataContext;

        public CityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(City obj)
        {
            await _dataContext.Cities.AddAsync(obj);
        }

        public Task<List<City>> GetAll()
        {
            return _dataContext.Cities.ToListAsync();
        }

        public Task<City> GetById(int id)
        {
            return _dataContext.Cities.SingleOrDefaultAsync((city) => city.Id == id);
        }

        public async Task Delete(City obj)
        {
            _dataContext.Cities.Remove(obj);
        }
    }
}
