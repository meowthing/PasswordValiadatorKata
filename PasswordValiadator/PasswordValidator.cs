using System.Text;
using System.Text.RegularExpressions;

namespace PasswordValiadator
{
    public class PasswordValidator
    {
        public PasswordValidator() { }

        public ValidationResult Validate(string password)
        {
            StringBuilder errorMsgBuilder = new StringBuilder();
            ValidationResult completeValidationResult = new ValidationResult() { IsValid = true };

            ValidationResult numResult = ContainsNumbers(password, 2);
            if (!numResult.IsValid)
            {
                completeValidationResult.IsValid = false;
                errorMsgBuilder.Append($"{numResult.Errors} ");
            }

            ValidationResult lenResult = MinLength(password, 8);
            if (!lenResult.IsValid)
            {
                completeValidationResult.IsValid = false;
                errorMsgBuilder.Append($"{lenResult.Errors} ");
            }

            ValidationResult capsResult = CapitalLetters(password, 1);
            if (!capsResult.IsValid)
            {
                completeValidationResult.IsValid = false;
                errorMsgBuilder.Append($"{capsResult.Errors} ");
            }

            ValidationResult specResult = SpecialCharacters(password, 1);
            if (!specResult.IsValid)
            {
                completeValidationResult.IsValid = false;
                errorMsgBuilder.Append($"{specResult.Errors} ");
            }

            completeValidationResult.Errors = errorMsgBuilder.ToString().Trim();
            return completeValidationResult;
        }

        public ValidationResult ContainsNumbers(string password, int minNum)
        {
            Regex regex = new Regex("[0-9]{2,}");

            return new ValidationResult() { IsValid = regex.IsMatch(password), Errors = $"The password must contain at least {minNum} numbers" };
        }

        public ValidationResult MinLength(string password, int minLength)
        {
            return new ValidationResult() { IsValid = password.Length >= minLength, Errors = $"Password must be at least {minLength} characters" };
        }

        public ValidationResult CapitalLetters(string password, int minCaps)
        {
            Regex regex = new Regex("[A-Z]{" + minCaps + ",}");

            return new ValidationResult() { IsValid = regex.IsMatch(password), Errors = $"Password must contain at least {minCaps} capital character{(minCaps > 1 ? "s" : "")}" };
        }

        public ValidationResult SpecialCharacters(string password, int minSpecials)
        {
            Regex regex = new Regex("[^a-zA-Z0-9]{" + minSpecials + ",}");

            return new ValidationResult() { IsValid = regex.IsMatch(password), Errors = $"Password must contain at least {minSpecials} special character{(minSpecials > 1 ? "s" : "")}" };
        }
    }
}
