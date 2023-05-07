using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Users.Commands
{
    public class ChangePassword : IRequest<StandardResponse>
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
    }
}
