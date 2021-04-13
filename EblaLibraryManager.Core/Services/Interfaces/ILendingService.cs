using EblaLibraryManager.Data.Identity;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services.Interfaces
{
    public interface ILendingService
    {
        Task CreateLendingAsync(int bookId, ApplicationUser user);
    }
}
