using MediatR;
using Microsoft.AspNetCore.Identity;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Users.Commands;

namespace UrzisoftCarflowBackendApp.UseCases.Users.CommandsHandlers
{
    public class RegisterHandler : IRequestHandler<Register, StandardResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<StandardResponse> Handle(Register request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);

            if (userExists != null)
            {
                return new StandardResponse
                {
                    Status = "Error",
                    Message = "User already exists!"
                };
            }

            User user = new User()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            
            if (!result.Succeeded)
            {
                return new StandardResponse
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                };
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Active))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Active));
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Active))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Active);
            }

            return new StandardResponse
            {
                Status = "Success",
                Message = "User created successfully!"
            };
        }
    }
}
