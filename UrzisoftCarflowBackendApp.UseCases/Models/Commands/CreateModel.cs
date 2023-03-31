using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Models.Commands
{
    public class CreateModel : IRequest<Model>
    {
        public string Name { get; set; }  
    }
}
