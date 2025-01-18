namespace ABCIncAPI_991690389.Models.DTO
{
    /// <summary>
    /// DTO for full employee
    /// used when grabing all employees
    /// </summary>
    public class EmployeeDTO
    {
        public int eId { get; set; }
        public string? eName { get; set; }
        public string? eEmail { get; set; }
        public string? eEmploymentType { get; set; }
        public int eDependentCount { get; set; }
        public int eSalary { get; set; }
    }
}
