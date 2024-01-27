using System.ComponentModel.DataAnnotations;

namespace PrivateCollection.Dto
{
    public class UserDto
    {

        public required string Username { get; set; }
        public required string password { get; set; }
        [EmailAddress]
        public required string email { get; set; }
        public Guid Token { get; set; }
    }
}
