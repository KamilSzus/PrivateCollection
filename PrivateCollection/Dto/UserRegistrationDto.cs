using System.ComponentModel.DataAnnotations;

namespace PrivateCollection.Dto
{
    public class UserRegistrationDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
