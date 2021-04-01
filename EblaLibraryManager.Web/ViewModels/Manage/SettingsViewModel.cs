namespace EblaLibraryManager.Web.ViewModels.Manage
{
    public class SettingsViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public PasswordSettingsViewModel PasswordSettings { get; set; }
    }
}
