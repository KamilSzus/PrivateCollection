using PrivateCollection.Models;

namespace PrivateCollection.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
