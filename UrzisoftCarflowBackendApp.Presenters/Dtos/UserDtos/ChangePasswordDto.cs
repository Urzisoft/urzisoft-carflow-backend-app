using System.ComponentModel.DataAnnotations;

namespace UrzisoftCarflowBackendApp.Presenters.Dtos.UserDtos
{
    public class ChangePasswordDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
