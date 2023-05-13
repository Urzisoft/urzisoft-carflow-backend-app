using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, IBrandRepository brandRepository, IFuelRepository fuelRepository, ICityRepository cityRepository, IModelRepository modelRepository, IGasStationRepository gasStationRepository, ICarServiceRepository carServiceRepository, ICarWashStationRepository carWashStationRepository, IPriceRepository priceRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            BrandRepository = brandRepository;
            CityRepository = cityRepository;
            ModelRepository = modelRepository;
            FuelRepository = fuelRepository;
            CarWashStationRepository = carWashStationRepository;
            GasStationRepository = gasStationRepository;
            CarServiceRepository = carServiceRepository;
            PriceRepository = priceRepository;
        }

        public ICarRepository CarRepository { get; private set; }
        public IModelRepository ModelRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public ICityRepository CityRepository { get; private set; }
        public IFuelRepository FuelRepository { get; private set; }
        public IGasStationRepository GasStationRepository { get; private set; }
        public ICarServiceRepository CarServiceRepository { get; private set; }
        public ICarWashStationRepository CarWashStationRepository { get; private set; }
        public IPriceRepository PriceRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

    }
}
