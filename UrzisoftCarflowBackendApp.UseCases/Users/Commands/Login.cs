using MediatR;
using UrzisoftCarflowBackendApp.Entities;

namespace UrzisoftCarflowBackendApp.UseCases.Users.Commands
{
    public class Login : IRequest<JwtResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }   
    }
}
