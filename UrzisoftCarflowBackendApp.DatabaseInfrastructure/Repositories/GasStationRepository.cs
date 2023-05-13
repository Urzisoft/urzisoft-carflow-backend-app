﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Repositories
{
    public class GasStationRepository : IGasStationRepository
    {
        private readonly DataContext _dataContext;

        public GasStationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(GasStation obj)
        {
            await _dataContext.GasStations.AddAsync(obj);
        }

        public Task<List<GasStation>> GetAll()
        {
            return _dataContext.GasStations.Include((station) => station.Fuel)
                .Include((station) => station.City).ToListAsync();
        }

        public Task<GasStation> GetById(int id)
        {
            return _dataContext.GasStations.Include((station) => station.Fuel)
                .Include((station) => station.City).SingleOrDefaultAsync((station) => station.Id == id);
        }

        public async Task Delete(GasStation obj)
        {
            _dataContext.GasStations.Remove(obj);
        }
    }
}
