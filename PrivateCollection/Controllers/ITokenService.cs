using PrivateCollection.Models;

namespace PrivateCollection.Controllers
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
