﻿using Microsoft.EntityFrameworkCore;
using PrivateCollection.Data;
using PrivateCollection.Dto;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;
using System;

namespace PrivateCollection.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly PrivateCollectionContext Context;

        public BookRepository(PrivateCollectionContext context)
        {
            this.Context = context;
        }

        public async Task<bool> BookExistAsync(long id)
        {
            return await this.Context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<Book> CreateBookAsync(BookDto book)
        {
            var existingBook = await GetBookByTitleAsync(book.Title);

            if (existingBook is null)
            {
                var newBook = new Book
                {
                    Title = book.Title,
                    Authors = book.Authors,
                    IsFinished = book.IsFinished,
                    StartDate = ConvertToDateTimeZone(book.StartDate),
                    EndDate = ConvertToDateTimeZone(book.EndDate),
                    ReadTime = book.IsFinished ? book.EndDate - book.StartDate : null
                };


                this.Context.Books.Add(newBook);
                this.Context.SaveChanges();

                return newBook;
            }

            existingBook.Authors = book.Authors;
            existingBook.StartDate = ConvertToDateTimeZone(book.StartDate);
            existingBook.EndDate = ConvertToDateTimeZone(book.EndDate);
            existingBook.ReadTime = book.IsFinished ? book.EndDate - book.StartDate : null;

            this.Context.Update(existingBook);
            this.Context.SaveChanges();

            return existingBook;
        }

        public async Task<Book> DeleteBookAsync(long bookId)
        {
            var bookToDelete = await this.Context.Books.FindAsync(bookId);

            if (bookToDelete is null)
                return null;

            this.Context.Books.Remove(bookToDelete);
            this.Context.SaveChanges();

            return bookToDelete;
        }

        public async Task<Book> FinishBookAsync(DateTime EndDate, string title)
        {
            var bookToFinish = await GetBookByTitleAsync(title);

            if (bookToFinish is null)
                return null;

            bookToFinish.EndDate = ConvertToDateTimeZone(EndDate);
            bookToFinish.ReadTime = EndDate - bookToFinish.StartDate;

            this.Context.Books.Update(bookToFinish);
            this.Context.SaveChanges();

            return bookToFinish;
        }

        public async Task<Book?> GetBookByIdAsync(long id)
        {
            return await this.Context.Books.FindAsync(id);
        }

        public async Task<Book?> GetBookByTitleAsync(string title)
        {
            return await this.Context.Books.FirstOrDefaultAsync(b => b.Title == title);
        }

        public async Task<ICollection<Book>> GetBooksAsync()
        {
            return await this.Context.Books.OrderBy(b => b.Title).ToListAsync();
        }

        public async Task<ICollection<Book>> GetUnfishedBooksAsync()
        {
            return await this.Context.Books.Where(b => b.IsFinished == false).ToListAsync();
        }

        private DateTime? ConvertToDateTimeZone(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return TimeZoneInfo.ConvertTimeToUtc(dateTime.Value.ToLocalTime());
            }

            return null;
        }
    }
}
