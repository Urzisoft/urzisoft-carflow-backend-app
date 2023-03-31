namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
<<<<<<< HEAD
        public IBrandRepository BrandRepository { get; }
=======
        public ICityRepository CityRepository { get; }
>>>>>>> origin/develop
        Task Save();
    }
}
