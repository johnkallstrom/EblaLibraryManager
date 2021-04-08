﻿namespace EblaLibraryManager.Web.ViewModels.Book
{
    public class BookSlimViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorSlimViewModel Author { get; set; }
        public string Genre { get; set; }
        public int TotalPages { get; set; }
        public AvailabilityStatusViewModel AvailabilityStatus { get; set; }
    }
}
