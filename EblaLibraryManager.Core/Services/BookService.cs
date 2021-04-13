using EblaLibraryManager.Core.Parameters;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data;
using EblaLibraryManager.Data.Exceptions;
using EblaLibraryManager.Data.Identity;
using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UpdateBook(Book book)
        {
            if (book is null) throw new BookNotFoundException("The book you are requesting does not exist");

            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public async Task CreateBookAsync(Book book)
        {
            if (book is null) throw new BookNotFoundException("The book you are requesting does not exist");

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public void DeleteBook(Book book)
        {
            if (book is null) throw new BookNotFoundException("The book you are requesting does not exist");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book is null) throw new BookNotFoundException("The book you are requesting does not exist.");

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(BookQueryParameters parameters)
        {
            if (parameters is null) throw new ArgumentNullException(nameof(parameters));

            if (string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                return await GetBooksAsync();
            }

            var collection = _context.Books
                .Include(b => b.Status)
                .Include(b => b.Author)
                .Include(b => b.Genre) as IQueryable<Book>;

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                string query = parameters.SearchTerm.Trim();
                collection = collection.Where(b => b.Title.Contains(query) || b.Author.Name.Contains(query) || b.Genre.Name.Contains(query));
            }

            return await collection.ToListAsync();
        }
    }
}