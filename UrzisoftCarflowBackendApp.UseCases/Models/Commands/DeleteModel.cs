using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Models.Commands
{
    public class DeleteModel : IRequest<Model>
    {
        public int ModelId { get; set; }
    }
}
