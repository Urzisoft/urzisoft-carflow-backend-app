namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IModelRepository ModelRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public ICityRepository CityRepository { get; }
        public IFuelRepository FuelRepository { get; }
        Task Save();
    }
}
