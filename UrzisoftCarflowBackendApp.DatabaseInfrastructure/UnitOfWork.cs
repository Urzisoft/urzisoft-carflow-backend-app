using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, ICarRepository carRepository)
        {
            _dataContext = dataContext;
            CarRepository = carRepository;
        }

        public ICarRepository CarRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
