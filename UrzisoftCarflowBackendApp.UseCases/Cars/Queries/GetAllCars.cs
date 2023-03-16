using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Queries
{
    public class GetAllCars : IRequest<List<Car>>
    {
    
    }
}
