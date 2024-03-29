﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            if (!ModelState.IsValid)
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
            if (await this.BookRepository.BookExistAsync(bookId))
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

            if (book is null)
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

            var newBook = await this.BookRepository.CreateBookAsync(book);

            return Ok(this.Mapper.Map<BookDto>(newBook));
        }

        /// <summary>
        /// Delete book by id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public async Task<IActionResult> DeleteBookById(long bookId)
        {
            var bookToDelete = await this.BookRepository.DeleteBookAsync(bookId);

            if (bookToDelete is null)
                return NotFound();


            return Ok(bookToDelete);
        }

        /// <summary>
        /// Updates reading time
        /// </summary>
        /// <param name="title"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public async Task<IActionResult> FinishReadingBook([BindRequired][FromQuery]string title, [BindRequired][FromQuery]DateTime endDate)
        {
            var finishedBook = await this.BookRepository.FinishBookAsync(endDate, title);

            if (finishedBook is null)
                return NotFound(); 
            
            return Ok(finishedBook);
        }
    }
}
