using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;

namespace PrivateCollection.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IBookRepository BookRepository;
        private readonly IMapper Mapper;

        public UserController(IBookRepository bookRepository, IMapper mapper)
        {
            this.BookRepository = bookRepository;
            this.Mapper = mapper;
        }

        [HttpPost("/registration")]
        public async Task<UserDto> Registration([FromBody] UserDto newUser)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Missing data");

            return newUser;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserDto newUser)
        {
            throw new NotImplementedException();
        }

    }
}
