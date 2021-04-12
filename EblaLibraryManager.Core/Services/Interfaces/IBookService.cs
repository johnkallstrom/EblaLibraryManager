using EblaLibraryManager.Core.Parameters;
using EblaLibraryManager.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services.Interfaces
{
    public interface IBookService
    {
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        Task CreateBookAsync(Book book);
        Task<Book> GetBookByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(BookQueryParameters parameters);
    }
}
