using EblaLibraryManager.Web.Validators;
using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace EblaLibraryManager.Tests.Validators
{
    [TestFixture]
    public class RegisterViewModelValidatorTests
    {
        private RegisterViewModelValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new RegisterViewModelValidator();
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenConfirmPasswordNotEqualPassword()
        {
            var model = new RegisterViewModel();
            model.Password = "password123";
            model.ConfirmPassword = "wrongconfirmpass123";

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.ConfirmPassword).WithErrorMessage("The password and confirmation password do not match.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenConfirmPasswordEqualPassword()
        {
            var model = new RegisterViewModel();
            model.Password = "password123";
            model.ConfirmPassword = "password123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.ConfirmPassword);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenUsernameIsDigitsOnly()
        {
            var model = new RegisterViewModel();
            model.Username = "123456789";

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Username).WithErrorMessage("The username you entered is not valid.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenUsernameIsNotDigitsOnly()
        {
            var model = new RegisterViewModel();
            model.Username = "username123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Username);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenUsernameIsNull()
        {
            var model = new RegisterViewModel();
            model.Username = null;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Username).WithErrorMessage("Please enter a username.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenUsernameIsNotNull()
        {
            var model = new RegisterViewModel();
            model.Username = "username123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Username);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenUsernameIsEmpty()
        {
            var model = new RegisterViewModel();
            model.Username = string.Empty;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Username).WithErrorMessage("Please enter a username.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenUsernameIsNotEmpty()
        {
            var model = new RegisterViewModel();
            model.Username = "username123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Username);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenPasswordIsNull()
        {
            var model = new RegisterViewModel();
            model.Password = null;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Password).WithErrorMessage("Please enter a password.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenPasswordIsNotNull()
        {
            var model = new RegisterViewModel();
            model.Password = "password123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenPasswordIsEmpty()
        {
            var model = new RegisterViewModel();
            model.Password = string.Empty;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Password).WithErrorMessage("Please enter a password.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenPasswordIsNotEmpty()
        {
            var model = new RegisterViewModel();
            model.Password = "password123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Password);
        }
    }
}
