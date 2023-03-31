using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, IBrandRepository brandRepository, IFuelRepository fuelRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            BrandRepository = brandRepository;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, ICityRepository cityRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            CityRepository = cityRepository;
            FuelRepository = fuelRepository;
        }

        public ICarRepository CarRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public ICityRepository CityRepository { get; private set; }

        public IFuelRepository FuelRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

    }
}
