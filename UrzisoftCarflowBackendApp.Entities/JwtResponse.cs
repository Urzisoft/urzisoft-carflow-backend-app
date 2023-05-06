namespace UrzisoftCarflowBackendApp.Entities
{
    public class JwtResponse
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
