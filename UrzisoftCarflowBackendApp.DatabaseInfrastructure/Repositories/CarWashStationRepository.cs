using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class CarWashStationRepository : ICarWashStationRepository
    {

        private readonly DataContext _dataContext;

        public CarWashStationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(CarWashStation obj)
        {
            await _dataContext.CarWashStations.AddAsync(obj);
        }

        public Task<List<CarWashStation>> GetAll()
        {
            return _dataContext.CarWashStations.Include((carWashStation) => carWashStation.City).ToListAsync();
        }

        public Task<CarWashStation> GetById(int id)
        {
            return _dataContext.CarWashStations.Include((carWashStation) => carWashStation.City).SingleOrDefaultAsync((carWashStation) => carWashStation.Id == id);
        }

        public async Task Delete(CarWashStation obj)
        {
            _dataContext.CarWashStations.Remove(obj);
        }
    }
}
