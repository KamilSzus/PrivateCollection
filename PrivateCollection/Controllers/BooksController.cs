﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;

namespace PrivateCollection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository BookRepository;
        private readonly IMapper Mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.BookRepository = bookRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        ///   Return all book from my private collection
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public async Task<IActionResult> GetBooks()
        {
            var books = await this.BookRepository.GetBooksAsync();

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(this.Mapper.Map<List<BookDto>>(books));
        }

        /// <summary>
        ///  Return book by id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBookById(long bookId)
        {
            if(await this.BookRepository.BookExistAsync(bookId))
                return NotFound();

            var book = await this.BookRepository.GetBookByIdAsync(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.Mapper.Map<BookDto>(book));
        }

        /// <summary>
        ///  Return book by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("title/{title}")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var book = await this.BookRepository.GetBookByTitleAsync(title);

            if(book is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.Mapper.Map<BookDto>(book));
        }

        /// <summary>
        ///  Return all Unfinished books book
        /// </summary>
        /// <returns></returns>
        [HttpGet("unfinishedBooks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public async Task<IActionResult> GetUnfinishedBooks()
        {
            return Ok(await this.BookRepository.GetUnfishedBooksAsync());
        }

        /// <summary>
        ///  Add book to collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public async Task<IActionResult> CreateBook([FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newBook = await this.BookRepository.CreateBook(book);

            return Ok(this.Mapper.Map<BookDto>(newBook));
        }
        
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
