namespace Wallet.API.Models.Request
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }
    }
}
