using Microsoft.AspNetCore.Identity;
using PrivateCollection.Controllers;
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
        private readonly ITokenService TokenService;

        public UserRepository(PrivateCollectionContext context, UserManager<User> userManager, ITokenService tokenService)
        {
            this.Context = context;
            this.UserManager = userManager;
            this.TokenService = tokenService;
        }

        public async Task<UserDto> CreateUser(UserRegistrationDto user)
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
                    return new UserDto
                    { 
                        Email = user.Email,
                        Password = user.Password,
                        Username = user.Username,
                        Token = TokenService.GenerateToken(newUser)
                    };
                }
            }

            return null;
        }
    }
}
