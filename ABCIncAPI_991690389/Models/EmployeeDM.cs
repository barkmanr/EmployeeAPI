using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ABCIncAPI_991690389.Models
{
    /// <summary>
    /// Table for EmployeeInfo
    /// </summary>
    public class EmployeeDM
    {
        [Key]
        public int eId { get; set; }
        public string? eName { get; set; }
        public string? eEmail { get; set; }
        public string? eEmploymentType { get; set; }
        public int eDependentCount { get; set; }
        public int eSalary { get; set; }
    }
}
