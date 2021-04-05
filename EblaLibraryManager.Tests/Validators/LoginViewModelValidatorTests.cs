using EblaLibraryManager.Web.Validators;
using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace EblaLibraryManager.Tests.Validators
{
    [TestFixture]
    public class LoginViewModelValidatorTests
    {
        private LoginViewModelValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new LoginViewModelValidator();
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenUsernameIsNull()
        {
            var model = new LoginViewModel();
            model.Username = null;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Username).WithErrorMessage("Please enter your username.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenUsernameIsNotNull()
        {
            var model = new LoginViewModel();
            model.Username = "username123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Username);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenUsernameIsEmpty()
        {
            var model = new LoginViewModel();
            model.Username = string.Empty;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Username).WithErrorMessage("Please enter your username.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenUsernameIsNotEmpty()
        {
            var model = new LoginViewModel();
            model.Username = "username123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Username);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenPasswordIsNull()
        {
            var model = new LoginViewModel();
            model.Password = null;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Password).WithErrorMessage("Please enter your password.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenPasswordIsNotNull()
        {
            var model = new LoginViewModel();
            model.Password = "password123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenPasswordIsEmpty()
        {
            var model = new LoginViewModel();
            model.Password = string.Empty;

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Password).WithErrorMessage("Please enter your password.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenPasswordIsNotEmpty()
        {
            var model = new LoginViewModel();
            model.Password = "password123";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Password);
        }
    }
}
