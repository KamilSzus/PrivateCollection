using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;

namespace PrivateCollection.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost("registration")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public async Task<UserDto> Registration([FromBody] UserRegistrationDto user)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Missing data");

            var newUser = await this.UserRepository.CreateUser(user);


            return newUser;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BoardGameDto>))]
        public async Task<UserLoggedDto> Login([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Missing data");

            var loggedUser = await this.UserRepository.LoginUser(user);

            if (loggedUser is null)
                return null;

            return loggedUser;
        }

    }
}
