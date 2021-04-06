using EblaLibraryManager.Core.Parameters;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data;
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

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _context.Books
                .Include(book => book.AvailabilityStatus)
                .Include(book => book.Author)
                .Include(book => book.Genre)
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
                .Include(book => book.AvailabilityStatus)
                .Include(book => book.Author)
                .Include(book => book.Genre) as IQueryable<Book>;

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                string query = parameters.SearchTerm.Trim();
                collection = collection.Where(book => book.Title.Contains(query) || book.Author.Name.Contains(query) || book.Genre.Name.Contains(query));
            }

            return await collection.ToListAsync();
        }
    }
}