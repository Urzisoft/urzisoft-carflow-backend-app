using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Models.Queries
{
    public class GetAllModels : IRequest<List<Model>>
    {
    }
}
