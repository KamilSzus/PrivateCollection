using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateCollection.Dto;
using PrivateCollection.Models;

namespace PrivateCollection.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> UserManager;

        public UserController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        [HttpPost("/registration")]
        public async Task<UserDto> Registration([FromBody] UserDto newUser)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserDto newUser)
        {
            throw new NotImplementedException();
        }

    }
}
