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

        [HttpPost("/registration")]
        public async Task<UserDto> Registration([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Missing data");

            var newUser = await this.UserRepository.CreateUser(user);


            return newUser;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserDto newUser)
        {
            throw new NotImplementedException();
        }

    }
}
