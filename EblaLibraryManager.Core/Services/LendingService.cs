using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data;
using EblaLibraryManager.Data.Enumerations;
using EblaLibraryManager.Data.Exceptions;
using EblaLibraryManager.Data.Identity;
using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services
{
    public class LendingService : ILendingService
    {
        private readonly IBookService _bookService;
        private readonly ApplicationDbContext _context;

        public LendingService(
            IBookService bookService,
            ApplicationDbContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        public async Task CreateLendingAsync(int bookId, ApplicationUser user)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book is null) throw new BookNotFoundException("The book you are requesting does not exist.");
            if (book.Status != BookStatusTypes.Available) throw new BookNotAvailableException("The book is not available.");

            // check user maximum borrowed books (5)

            var lending = new Lending
            {
                Book = book,
                BookId = book.Id,
                User = user,
                UserId = user.Id,
                Created = DateTime.Now,
                Expiration = DateTime.Now.AddDays(30)
            };

            book.Status = BookStatusTypes.Loaned;
            book.Borrowed = lending.Created;
            book.DueDate = lending.Expiration;

            _bookService.UpdateBook(book);

            if (lending != null)
            {
                await _context.Lendings.AddAsync(lending);
                await _context.SaveChangesAsync();
            }
        }
    }
}
