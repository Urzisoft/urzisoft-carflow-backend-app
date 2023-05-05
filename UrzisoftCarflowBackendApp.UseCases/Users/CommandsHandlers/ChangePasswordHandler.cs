using MediatR;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Users.Commands;

namespace UrzisoftCarflowBackendApp.UseCases.Users.CommandsHandlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePassword, RegisterResponse>
    {
        public Task<RegisterResponse> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
