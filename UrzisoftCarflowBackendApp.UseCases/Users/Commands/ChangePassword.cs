using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Users.Commands
{
    public class ChangePassword : IRequest<RegisterResponse>
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
