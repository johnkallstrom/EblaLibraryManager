using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels.Book
{
    public class BookListViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<BookSlimViewModel> Books { get; set; }
    }
}
