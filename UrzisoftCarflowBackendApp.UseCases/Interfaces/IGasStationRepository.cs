using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public interface IGasStationRepository
    {
        Task Create(GasStation obj);
        Task<List<GasStation>> GetAll();
        Task<GasStation> GetById(int id);
        Task Delete(GasStation obj);
    }
    
    
}

