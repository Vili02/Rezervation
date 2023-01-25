using System.ComponentModel.DataAnnotations;

namespace Rezervation.DTOs
{
    public class AuthenticateRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
