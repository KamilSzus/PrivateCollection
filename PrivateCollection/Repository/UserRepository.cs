using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly SignInManager<User> SignInManager;
        private readonly ITokenService TokenService;

        public UserRepository(PrivateCollectionContext context, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            this.Context = context;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
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
        public async Task<UserLoggedDto?> LoginUser(UserLoginDto user)
        {
            var loggedUser = await this.UserManager.Users.FirstOrDefaultAsync(u => u.Email == user.Email.ToLower());

            if (loggedUser is null)
                return null;

            var result = await this.SignInManager.CheckPasswordSignInAsync(loggedUser, user.Password, false);

            if (!result.Succeeded)
                return null;

            return new UserLoggedDto
            {
                Email = loggedUser.Email,
                UserName = loggedUser.UserName,
                Token = TokenService.GenerateToken(loggedUser)
            };
        }
    }
}
