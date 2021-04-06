namespace EblaLibraryManager.Web.ViewModels
{
    public class BookSlimViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int TotalPages { get; set; }
        public AvailabilityStatusViewModel AvailabilityStatus { get; set; }
    }
}
