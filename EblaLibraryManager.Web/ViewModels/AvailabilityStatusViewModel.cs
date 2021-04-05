using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels
{
    public class AvailabilityStatusViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
