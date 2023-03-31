using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

<<<<<<< HEAD
        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, IBrandRepository brandRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            BrandRepository = brandRepository;
=======
        public UnitOfWork(DataContext dataContext, ICarRepository carRepository, ICityRepository cityRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
            CityRepository = cityRepository;
>>>>>>> origin/develop
        }

        public ICarRepository CarRepository { get; private set; }

<<<<<<< HEAD
        public IBrandRepository BrandRepository { get; private set; }
=======
        public ICityRepository CityRepository { get; private set; }
>>>>>>> origin/develop

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

    }
}
