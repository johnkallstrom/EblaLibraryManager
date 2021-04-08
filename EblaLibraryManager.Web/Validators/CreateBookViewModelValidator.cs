﻿using EblaLibraryManager.Web.ViewModels.Book;
using FluentValidation;

namespace EblaLibraryManager.Web.Validators
{
    public class CreateBookViewModelValidator : AbstractValidator<CreateBookViewModel>
    {
        public CreateBookViewModelValidator()
        {
            RuleFor(model => model.Title)
                .NotNull().WithMessage("Please enter a title.")
                .NotEmpty().WithMessage("Please enter a title.")
                .MaximumLength(50).WithMessage("The title cannot be longer than 50 characters.");

            RuleFor(model => model.Language)
                .NotNull().WithMessage("Please choose a language.")
                .NotEmpty().WithMessage("Please choose a language.");

            RuleFor(model => model.GenreId)
                .NotEmpty().WithMessage("Please choose a genre.");

            RuleFor(model => model.Publisher)
                .MaximumLength(50).WithMessage("The publisher cannot be longer than 50 characters.");

            RuleFor(model => model.TotalPages)
                .NotEmpty().WithMessage("Please enter total pages.");
        }
    }
}