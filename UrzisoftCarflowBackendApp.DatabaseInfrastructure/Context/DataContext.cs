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

    public DbSet<Car> Cars { get; set; }
}