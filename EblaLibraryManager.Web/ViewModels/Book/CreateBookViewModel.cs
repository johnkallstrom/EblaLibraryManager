namespace EblaLibraryManager.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public int TotalPages { get; set; }
        public AuthorViewModel Author { get; set; }
        public GenreViewModel Genre { get; set; }
    }
}
