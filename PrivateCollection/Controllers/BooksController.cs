using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;

namespace PrivateCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository BookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.BookRepository = bookRepository;
        }

        /// <summary>
        ///   Return all book from my private collection
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public async Task<IActionResult> GetBooks()
        {
            var books = await this.BookRepository.GetBooks();

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(books);
        }
     //
     //   /// <summary>
     //   ///  Add book to collection
     //   /// </summary>
     //   /// <param name="book"></param>
     //   /// <returns></returns>
     //   [HttpPost]
     //   public async Task<IActionResult> CreateBook([FromBody] Book book)
     //   {
     //       if (!ModelState.IsValid)
     //           return BadRequest(ModelState);
     //
     //
     //       if (await BookExists(book))
     //           return Conflict("A book with the same title already exists.");
     //
     //       await this.Context.Books.AddAsync(book);
     //       await this.Context.SaveChangesAsync();
     //
     //       return CreatedAtAction(nameof(GetBooks), new { book.Id }, book);
     //   }
     //
     //   /// <summary>
     //   /// Delete book by title
     //   /// </summary>
     //   /// <param name="title"></param>
     //   /// <returns></returns>
     //   [HttpDelete("{title}")]
     //   public async Task<IActionResult> DeleteBookByTitle(string title)
     //   {
     //       var bookToDelete = await this.Context.Books.FirstOrDefaultAsync(b => b.Title.Equals(title));
     //
     //       if (bookToDelete is null)
     //           return NotFound();
     //
     //       this.Context.Books.Remove(bookToDelete);
     //       await this.Context.SaveChangesAsync();
     //
     //       return NoContent();
     //   }
     //
     //   /// <summary>
     //   /// Update book
     //   /// </summary>
     //   /// <param name="id"></param>
     //   /// <param name="book"></param>
     //   /// <returns></returns>
     //   [HttpPut("{id}")]
     //   public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
     //   {
     //       if (!ModelState.IsValid || id < 0)
     //           return BadRequest();
     //
     //       this.Context.Books.Entry(book).State = EntityState.Modified;
     //
     //       try
     //       {
     //           await this.Context.SaveChangesAsync();
     //       }
     //       catch (DbUpdateConcurrencyException)
     //       {
     //           if (! await BookExists(book))
     //               return NotFound();
     //           else
     //               throw new DbUpdateConcurrencyException("Update Exception");
     //       }
     //
     //       return Ok(book);
     //
     //   }
     //
     //   async Task<bool> BookExists(Book book)
     //   {
     //       return await this.Context.Books.AnyAsync(b => b.Title.Equals(book.Title));
     //   }
    }
}
