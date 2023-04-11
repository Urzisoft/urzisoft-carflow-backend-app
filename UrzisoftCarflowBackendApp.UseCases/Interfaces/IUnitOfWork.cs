namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IModelRepository ModelRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public ICityRepository CityRepository { get; }
        public IFuelRepository FuelRepository { get; }
        public IGasStationRepository GasStationRepository { get; }
        public ICarWashStationRepository CarWashStationRepository { get; }
        public ICarServiceRepository CarServiceRepository { get; }
        Task Save();
    }
}
