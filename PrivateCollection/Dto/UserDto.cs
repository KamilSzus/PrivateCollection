using System.ComponentModel.DataAnnotations;

namespace PrivateCollection.Dto
{
    public class UserDto
    {

        public required string Username { get; set; }
        public required string Password { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
