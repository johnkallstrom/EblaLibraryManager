using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EblaLibraryManager.Web.Validators
{
    public class SettingsViewModelValidator : AbstractValidator<SettingsViewModel>
    {
        public SettingsViewModelValidator()
        {
            RuleFor(model => model.Email).Custom((email, context) =>
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
