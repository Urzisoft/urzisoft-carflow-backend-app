using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
        }
        public UnitOfWork(DataContext dataContext, ICityRepository cityRepository)
        {
            _dataContext = dataContext;
            CityRepository = cityRepository;
        }

        public ICarRepository CarRepository { get; private set; }

        public ICityRepository CityRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
