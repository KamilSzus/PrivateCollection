using PrivateCollection.Dto;

namespace PrivateCollection.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDto> CreateUser(UserDto user);
    }
}
