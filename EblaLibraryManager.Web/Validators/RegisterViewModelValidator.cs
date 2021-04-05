using EblaLibraryManager.Core.Extensions;
using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation;

namespace EblaLibraryManager.Web.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(model => model.Username)
                .NotNull().WithMessage("Please enter a username.")
                .NotEmpty().WithMessage("Please enter a username.")
                .Must(username => !username.IsDigitsOnly()).WithMessage("The username you entered is not valid.");

            RuleFor(model => model.Password)
                .NotNull().WithMessage("Please enter a password.")
                .NotEmpty().WithMessage("Please enter a password.");

            RuleFor(model => model.ConfirmPassword)
                .NotNull().WithMessage("Please enter a confirm password.")
                .NotEmpty().WithMessage("Please enter a confirm password.")
                .Equal(model => model.Password).WithMessage("The password and confirmation password do not match.");
        }
    }
}
