using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data;
using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services
{
    public class BookService : IBookService
    {
        private readonly EblaLibraryManagerContext _context;

        public BookService(EblaLibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }
    }
}
