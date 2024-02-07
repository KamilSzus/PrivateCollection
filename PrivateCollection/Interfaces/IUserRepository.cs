using PrivateCollection.Dto;

namespace PrivateCollection.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDto> CreateUser(UserRegistrationDto user);
        public Task<UserLoggedDto?> LoginUser(UserLoginDto user);
    }
}
