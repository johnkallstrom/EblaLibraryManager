using EblaLibraryManager.Core.Parameters;
using EblaLibraryManager.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBookByIdAsync(int bookId);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetBooksAsync(BookQueryParameters parameters);
    }
}
