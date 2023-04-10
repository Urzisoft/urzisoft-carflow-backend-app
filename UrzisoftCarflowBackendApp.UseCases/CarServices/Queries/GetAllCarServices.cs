using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.Queries
{
    public class GetAllCarServices : IRequest<List<CarService>>
    {
    }
}
