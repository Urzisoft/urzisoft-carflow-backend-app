using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cities.Queries
{
    public class GetCityById: IRequest<City>
    {
        public int Id { get; set; }
    }
}
