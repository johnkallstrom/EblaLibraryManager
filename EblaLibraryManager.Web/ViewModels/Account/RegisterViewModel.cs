using System.ComponentModel.DataAnnotations;

namespace EblaLibraryManager.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password, ErrorMessage = "Please enter a valid password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password, ErrorMessage = "Please enter a valid confirm password.")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
