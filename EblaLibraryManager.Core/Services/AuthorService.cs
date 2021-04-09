using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data;
using EblaLibraryManager.Data.Exceptions;
using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            var author = await _context.Authors
                .Include(a => a.Books).ThenInclude(b => b.Genre)
                .Include(a => a.Books).ThenInclude(b => b.AvailabilityStatus)
                .FirstOrDefaultAsync(a => a.Id == authorId);

            if (author is null) throw new AuthorNotFoundException("The author you are requesting does not exist.");

            return author;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync() => await _context.Authors.ToListAsync();
    }
}
