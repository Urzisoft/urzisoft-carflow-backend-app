using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Cars.Queries
{
    public class GetCarById: IRequest<Car>
    {
        public int Id { get; set; }
    }
}
