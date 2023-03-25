namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IModelRepository ModelRepository { get; }
        Task Save();
    }
}
