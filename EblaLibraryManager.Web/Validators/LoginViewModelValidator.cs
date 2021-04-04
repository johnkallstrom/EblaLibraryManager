using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation;

namespace EblaLibraryManager.Web.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(model => model.Username)
                .NotNull().WithMessage("Please enter your username.")
                .NotEmpty().WithMessage("Please enter your username.");

            RuleFor(model => model.Password)
                .NotNull().WithMessage("Please enter your password.")
                .NotEmpty().WithMessage("Please enter your password.");
        }
    }
}
