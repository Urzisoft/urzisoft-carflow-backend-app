using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.CarServices.Queries
{
    public class GetCarServiceById : IRequest<CarService>
    {
        public int Id { get; set; }
    }
}
