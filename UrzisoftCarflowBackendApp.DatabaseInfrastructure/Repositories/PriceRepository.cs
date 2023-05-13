using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class PriceRepository : IPriceRepository
    {

        private readonly DataContext _dataContext;

        public PriceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(Price obj)
        {
            await _dataContext.Prices.AddAsync(obj);
        }

        public Task<List<Price>> GetAll()
        {
            return _dataContext.Prices.ToListAsync();
        }

        public Task<Price> GetById(int id)
        {
            return _dataContext.Prices.SingleOrDefaultAsync((price) => price.Id == id);
        }

        public async Task Delete(Price obj)
        {
            _dataContext.Prices.Remove(obj);
        }
    }
}
