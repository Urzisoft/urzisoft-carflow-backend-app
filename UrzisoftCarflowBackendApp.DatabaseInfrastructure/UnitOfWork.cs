using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, IBrandRepository brandRepository, IFuelRepository fuelRepository, ICityRepository cityRepository, IModelRepository modelRepository, IGasStationRepository gasStationRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            BrandRepository = brandRepository;
            CityRepository = cityRepository;
            ModelRepository = modelRepository;
            FuelRepository = fuelRepository;
            GasStationRepository = gasStationRepository;
        }

        public ICarRepository CarRepository { get; private set; }
        public IModelRepository ModelRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public ICityRepository CityRepository { get; private set; }
        public IFuelRepository FuelRepository { get; private set; }
        public IGasStationRepository GasStationRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

    }
}
