using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {

        private readonly DataContext _dataContext;

        public BrandRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task Create(Brand obj)
        {
            await _dataContext.Brands.AddAsync(obj);
        }

        public Task<List<Brand>> GetAll()
        {
            return _dataContext.Brands.ToListAsync();
        }

        public Task<Brand> GetById(int id)
        {
            return _dataContext.Brands.SingleOrDefaultAsync((brand) => brand.Id == id);
        }

        public async Task Delete(Brand obj)
        {
            _dataContext.Brands.Remove(obj);
        }



    }
}
