using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateCollection.Models;

namespace PrivateCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly PrivateCollectionContext Context;

        public BooksController(PrivateCollectionContext context)
        {
            this.Context = context;
        }

        /// <summary>
        ///   Return all book from my private collection
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var items = await this.Context.Books.ToListAsync();
            return Ok(items);
        }

        /// <summary>
        ///  Add book to collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]Book book)
        {
            if(ModelState.IsValid)
            {
                if (await this.Context.Books.AnyAsync(b => b.Title.Equals(book.Title)))
                {
                    return Conflict("A book with the same title already exists.");
                }

                await this.Context.Books.AddAsync(book);
                await this.Context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBooks), new { book.Id }, book);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook()
        {
            throw new NotImplementedException();
        }
    }
    }
