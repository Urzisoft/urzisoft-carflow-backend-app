using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Models.Commands
{
    public class UpdateModel : IRequest<Model>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
