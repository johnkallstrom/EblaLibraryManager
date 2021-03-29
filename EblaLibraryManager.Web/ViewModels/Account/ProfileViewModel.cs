using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels.Account
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
