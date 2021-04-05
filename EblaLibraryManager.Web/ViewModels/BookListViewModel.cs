using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels
{
    public class BookListViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
