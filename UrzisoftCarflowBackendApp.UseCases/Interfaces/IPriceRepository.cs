using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Interfaces
{
    public class IPriceRepository
    {
        Task Create(Brand obj);
        Task<List<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task Delete(Brand obj);
    }
}
