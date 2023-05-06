using MediatR;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Cryptography;
using System.Text;
using UrzisoftCarflowBackendApp.Entities;
using UrzisoftCarflowBackendApp.UseCases.Interfaces;
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

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<StandardResponse> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            string newPasswordHash = HashPassword(request.NewPassword);


            if (user is not null)
            {
                user.PasswordHash = newPasswordHash;
                var result = await _userManager.UpdateAsync(user);

                if (result is not null)
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
