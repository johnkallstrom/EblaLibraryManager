using EblaLibraryManager.Web.ViewModels.Book;
using System;
using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Born { get; set; }
        public DateTime? Death { get; set; }
        public string Country { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
