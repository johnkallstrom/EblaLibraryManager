using System;

namespace EblaLibraryManager.Web.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public int TotalPages { get; set; }
        public DateTime? Borrowed { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
