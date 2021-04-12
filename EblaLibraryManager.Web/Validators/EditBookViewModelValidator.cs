using EblaLibraryManager.Web.ViewModels.Book;
using FluentValidation;

namespace EblaLibraryManager.Web.Validators
{
    public class EditBookViewModelValidator : AbstractValidator<EditBookViewModel>
    {
        public EditBookViewModelValidator()
        {
            RuleFor(model => model.Title)
                .MaximumLength(50).WithMessage("The title cannot be longer than 50 characters.");

            RuleFor(model => model.Publisher)
                .MaximumLength(50).WithMessage("The publisher cannot be longer than 50 characters.");
        }
    }
}
