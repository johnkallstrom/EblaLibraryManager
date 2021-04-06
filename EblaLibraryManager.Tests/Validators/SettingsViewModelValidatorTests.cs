using EblaLibraryManager.Web.Validators;
using EblaLibraryManager.Web.ViewModels.Account;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace EblaLibraryManager.Tests.Validators
{
    [TestFixture]
    public class SettingsViewModelValidatorTests
    {
        private SettingsViewModelValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new SettingsViewModelValidator();
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenPhoneNumberRegexValidationFails()
        {
            var model = new SettingsViewModel();
            model.PhoneNumber = "notvalidphonenumber";

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.PhoneNumber).WithErrorMessage("The phone number you entered is not valid.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenPhoneNumberRegexValidationSucceeded()
        {
            var model = new SettingsViewModel();
            model.PhoneNumber = "08-1234567";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.PhoneNumber);
        }

        [Test]
        public void ShouldReturnErrorMessage_WhenEmailRegexValidationFails()
        {
            var model = new SettingsViewModel();
            model.Email = "incorrectemail123";

            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Email).WithErrorMessage("The email you entered is not valid.");
        }

        [Test]
        public void ShouldNotReturnErrorMessage_WhenEmailRegexValidationSucceeded()
        {
            var model = new SettingsViewModel();
            model.Email = "validemail@mail.com";

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(model => model.Email);
        }
    }
}
