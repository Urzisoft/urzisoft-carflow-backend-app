using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class CarServiceRepository : ICarServiceRepository
    {
        private readonly DataContext _dataContext;

        public CarServiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(CarService obj)
        {
            await _dataContext.CarServices.AddAsync(obj);
        }

        public Task<List<CarService>> GetAll()
        {
            return _dataContext.CarServices.Include((carService) => carService.BrandsListIds).ToListAsync();
        }

        public Task<CarService> GetById(int id)
        {
            return _dataContext.CarServices.Include((carService) => carService.BrandsListIds).SingleOrDefaultAsync((carService) => carService.Id == id);
        }

        public async Task Delete(CarService obj)
        {
            _dataContext.CarServices.Remove(obj);
        }
    }
}
