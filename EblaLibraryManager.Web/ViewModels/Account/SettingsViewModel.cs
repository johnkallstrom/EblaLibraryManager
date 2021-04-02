﻿using System.ComponentModel.DataAnnotations;

namespace EblaLibraryManager.Web.ViewModels.Account
{
    public class SettingsViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
