using MediatR;
using Microsoft.AspNetCore.Identity;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Users.Commands;

namespace UrzisoftCarflowBackendApp.UseCases.Users.CommandsHandlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePassword, StandardResponse>
    {
        private readonly UserManager<User> _userManager;

        public ChangePasswordHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<StandardResponse> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            string newPasswordHash = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);


            if (user is not null)
            {
                user.PasswordHash = newPasswordHash;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return new StandardResponse
                    {
                        Status = "Success",
                        Message = "Password updated succesfully!"
                    };
                } else
                {
                    return new StandardResponse
                    {
                        Status = "Error",
                        Message = "Error when updating password!"
                    };
                }
            }


            return new StandardResponse
            {
                Status = "Error",
                Message = "Unable to find user!"
            };
        }
    }
}
