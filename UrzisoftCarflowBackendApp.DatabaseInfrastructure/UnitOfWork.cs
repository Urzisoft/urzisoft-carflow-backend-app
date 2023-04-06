using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;
    public ICarRepository CarRepository { get; }
    public IGasStationRepository GasStationRepository { get; }

    public UnitOfWork(DataContext dataContext, ICarRepository carRepository, IGasStationRepository gasStationRepository)
    {
        _dataContext = dataContext;
        CarRepository = carRepository;
        GasStationRepository = gasStationRepository;
    }

    public async Task Save()
    {
        await _dataContext.SaveChangesAsync();
    }
}