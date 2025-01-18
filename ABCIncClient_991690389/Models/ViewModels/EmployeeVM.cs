using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ABCIncClient_991690389.Models.Validations;

namespace ABCIncClient_991690389.Models.ViewModels
{
    /// <summary>
    /// View model for employee
    /// Uses validations
    /// </summary>
    public class EmployeeVM
    {
        [Range(1, 10000, ErrorMessage = "Must be in range: 1-10000")]
        [DisplayName("EmployeeId")]
        public int eId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(50, ErrorMessage = "Can't be 50+ characters")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only letters")]
        [DisplayName("Employee Name")]
        public string? eName { get; set; }
        [EmailRyanAtrribute]
        [DisplayName("Email Address")]
        public string? eEmail { get; set; }
        [EmpTypeRyanAttribute]
        [DisplayName("Type")]
        public string? eEmploymentType { get; set; }
        [Range(0, 5, ErrorMessage = "Must be in range: 0-5")]
        public int eDependentCount { get; set; }
        [Range(54, int.MaxValue, ErrorMessage = "Value must me above the sum of my student number: 54")]
        [DisplayName("Salary")]
        public int eSalary { get; set; }
    }
}
