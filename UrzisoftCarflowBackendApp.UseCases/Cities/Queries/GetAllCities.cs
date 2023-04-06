using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.Queries
{
    public class GetAllCities : IRequest<List<City>>
    {
    }
}
