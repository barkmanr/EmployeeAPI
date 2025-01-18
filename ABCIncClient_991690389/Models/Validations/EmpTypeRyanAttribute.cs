using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;

namespace ABCIncClient_991690389.Models.Validations
{
    /// <summary>
    /// Custom validation for type. Makes sure it is in List
    /// </summary>
    public class EmpTypeRyanAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (value != null)
            {
                if (Validations.Contains(value.ToString()))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage ?? "Full-Time, Part-Time, or Contract");
            }
            return new ValidationResult(ErrorMessage ?? "Employment type is required");
        }

        private List<string> Validations = new List<string>() {"Full-Time", "Part-Time", "Contract" }; 
    }
}
