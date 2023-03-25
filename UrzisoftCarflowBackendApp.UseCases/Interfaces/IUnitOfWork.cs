namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public ICityRepository CityRepository { get; }
        Task Save();
    }
}
