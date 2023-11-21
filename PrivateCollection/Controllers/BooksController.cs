using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateCollection.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrivateCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly PrivateCollectionContext _context;

        public BooksController(PrivateCollectionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var items = await _context.Books.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]Book book)
        {
            if(ModelState.IsValid)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBooks", new { book.Id }, book);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
    }
    }
