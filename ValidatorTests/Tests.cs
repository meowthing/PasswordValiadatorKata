using PasswordValiadator;
using ValidationResult = PasswordValiadator.ValidationResult;

namespace ValidatorTests
{
    public class Tests
    {
        PasswordValidator pwValidator;

        [SetUp]
        public void Setup()
        {
            pwValidator = new PasswordValidator();
        }


        [Test]
        public void PasswordMustBeMinLength()
        {
            ValidationResult validPwResult = pwValidator.Validate("paword");

            Assert.That(validPwResult.Errors, Does.Contain("Password must be at least 8 characters"));
        }


        [Test]
        public void PasswordMustContainNumbers()
        {
            ValidationResult validPwResult = pwValidator.Validate("password");

            Assert.That(validPwResult.Errors, Does.Contain("The password must contain at least 2 numbers"));
        }


        [Test]
        public void PasswordMustContainOneCapitalCharacter()
        {
            ValidationResult validPwResult = pwValidator.Validate("password");

            Assert.That(validPwResult.Errors, Does.Contain("Password must contain at least 1 capital character"));
        }


        [Test]
        public void PasswordMustContainOneSpecialCharacter()
        {
            ValidationResult validPwResult = pwValidator.Validate("password");

            Assert.That(validPwResult.Errors, Does.Contain("Password must contain at least 1 special character"));
        }
    }
}