using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.DatabaseInfrastructure.Context;

public class DataContext : IdentityDbContext<User>
{
    public DataContext()
    {

    }

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarService> CarServices { get; set; }
    public DbSet<CarWashStation> CarWashStations { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<GasStation> GasStations { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<User> TheUsers { get; set; }
    public DbSet<GasStation> gasStations { get; set; }
}