using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, IBrandRepository brandRepository, IFuelRepository fuelRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            BrandRepository = brandRepository;
            FuelRepository = fuelRepository;
        }

        public ICarRepository CarRepository { get; private set; }
        public IBrandRepository BrandRepository { get; private set; }
        public IFuelRepository FuelRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

    }
}
