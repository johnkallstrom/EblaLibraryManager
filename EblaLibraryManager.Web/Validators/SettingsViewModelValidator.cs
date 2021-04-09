using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EblaLibraryManager.Web.Validators
{
    public class SettingsViewModelValidator : AbstractValidator<SettingsViewModel>
    {
        public SettingsViewModelValidator()
        {
            RuleFor(model => model.PhoneNumber).Custom((phoneNumber, context) =>
            {
                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    Regex regex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
                    Match match = regex.Match(phoneNumber);

                    if (!match.Success)
                    {
                        context.AddFailure("The phone number you entered is not valid.");
                    }
                }
            });

            RuleFor(model => model.Email)
                .NotNull().WithMessage("Please enter your email.")
                .NotEmpty().WithMessage("Please enter your email.")
                .Custom((email, context) =>
                {
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match = regex.Match(email);

                        if (!match.Success)
                        {
                            context.AddFailure("The email you entered is not valid.");
                        }
                    }
                });
        }
    }
}
