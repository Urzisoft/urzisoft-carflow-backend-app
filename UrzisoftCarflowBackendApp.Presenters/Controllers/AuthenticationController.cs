using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrzisoftCarflowBackendApp.Presenters.Dtos.UserDtos;
using UrzisoftCarflowBackendApp.UseCases.Users.Commands;

namespace UrzisoftCarflowBackendApp.Presenters.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var command = new Register
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
            };

            var result = await _mediator.Send(command);

            return result.Status == "Error" ? StatusCode(StatusCodes.Status500InternalServerError, result) : Ok(result);
        }

        [HttpPost]
        [Route("admin-register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            var command = new RegisterAdmin
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
            };

            var result = await _mediator.Send(command);

            return result.Status == "Error" ? StatusCode(StatusCodes.Status500InternalServerError, result) : Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto logInDto)
        {
            var command = new Login
            {
                Username = logInDto.Username,
                Password = logInDto.Password,
            };

            var result = await _mediator.Send(command);

            return result == null ? Unauthorized() : Ok(result);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var command = new ChangePassword
            {
                Username = changePasswordDto.Username,
                NewPassword = changePasswordDto.NewPassword,
            };

            var result = await _mediator.Send(command);

            return result == null ? Unauthorized() : Ok(result);
        }
    }
}
