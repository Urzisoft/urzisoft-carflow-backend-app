using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Models.Queries
{
    public class GetModelById : IRequest<Model>
    {
        public int Id { get; set; }
    }
}
