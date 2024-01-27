using Microsoft.AspNetCore.Identity;
using PrivateCollection.Data;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;

namespace PrivateCollection.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PrivateCollectionContext Context;
        private readonly UserManager<User> UserManager;

        public UserRepository(PrivateCollectionContext context, UserManager<User> userManager)
        {
            this.Context = context;
            this.UserManager = userManager;
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            var newUser = new User
            {
                UserName = user.Username,
                Email = user.Email
            };

            var createdUser = await this.UserManager.CreateAsync(newUser, user.Password);

            if (createdUser.Succeeded)
            {
                var userRole = await this.UserManager.AddToRoleAsync(newUser, "User");

                if (userRole.Succeeded)
                {
                    return user;
                }
            }

            return user;
        }
    }
}
