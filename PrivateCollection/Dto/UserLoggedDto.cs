namespace PrivateCollection.Dto
{
    public class UserLoggedDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}