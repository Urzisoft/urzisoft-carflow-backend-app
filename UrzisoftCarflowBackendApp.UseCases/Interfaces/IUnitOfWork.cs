using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IGasStationRepository GasStationRepository { get; }
        Task Save();
    }
}
