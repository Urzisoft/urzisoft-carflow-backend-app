using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly DataContext _dataContext;

        public CarRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(Car obj)
        {
            await _dataContext.Cars.AddAsync(obj);
        }

        public Task<List<Car>> GetAll()
        {
            return _dataContext.Cars.ToListAsync();
        }

        public Task<Car> GetById(int id)
        {
            return _dataContext.Cars.SingleOrDefaultAsync((car) => car.Id == id);
        }

        public async Task Delete(Car obj)
        {
            _dataContext.Cars.Remove(obj);
        }
    }
}
