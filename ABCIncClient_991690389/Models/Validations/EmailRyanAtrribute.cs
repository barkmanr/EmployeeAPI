using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ABCIncClient_991690389.Models.Validations
{
    /// <summary>
    /// Custom Validation for email
    /// Uses regex to make sure it is lower case and has @ symbol in between 
    /// Optional '.' ex: .ca
    /// </summary>
    public class EmailRyanAtrribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (value != null)
            {
                string pattern = @"^[a-z]+@[a-z]+(.[a-z]+)?$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex.IsMatch(value.ToString()))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage ?? "Does not match format of email");
            }
            return new ValidationResult(ErrorMessage ?? "Email is required");
        }
    }
}
