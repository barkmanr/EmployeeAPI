using ABCIncAPI_991690389.Context;
using ABCIncAPI_991690389.Models;
using ABCIncAPI_991690389.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCIncAPI_991690389.Controllers
{
    /// <summary>
    /// Api controller for employee info
    /// Has the context of db
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        /// <summary>
        /// Returns all employees through DTO
        /// </summary>
        /// <returns>List of employees (DTO)</returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var Employees = await _employeeContext.EmployeeInfo.ToListAsync();
            var list = new List<EmployeeDTO>();
            foreach (var Employee in Employees)
            {
                list.Add(new EmployeeDTO()
                {
                    eId = Employee.eId,
                    eName = Employee.eName,
                    eEmail = Employee.eEmail,
                    eEmploymentType = Employee.eEmploymentType,
                    eDependentCount = Employee.eDependentCount,
                    eSalary = Employee.eSalary,
                });
            }
            return Ok(list);
        }
        /// <summary>
        /// Get an employee with a matching id 
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var Employee = await _employeeContext.EmployeeInfo.FindAsync(id);
            if (Employee == null) { return NotFound(); }
            return Ok(Employee);
        }
        /// <summary>
        /// Adds an employee to the data base
        /// </summary>
        /// <param name="emp"> New Employee </param>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDM emp)
        {
            await _employeeContext.EmployeeInfo.AddAsync(emp);
            await _employeeContext.SaveChangesAsync();
            var Employees = await _employeeContext.EmployeeInfo.ToListAsync();
            return Ok(Employees);
        }
        /// <summary>
        /// Gets an id and replaces it with emplyee data
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDM emp)
        {
            var Employee = await _employeeContext.EmployeeInfo.FindAsync(id);
            if (Employee == null) { return NotFound(); }
            Employee.eName = emp.eName;
            Employee.eEmail = emp.eEmail;
            Employee.eEmploymentType = emp.eEmploymentType;
            Employee.eDependentCount = emp.eDependentCount;
            Employee.eSalary = emp.eSalary;
            await _employeeContext.SaveChangesAsync();
            return Ok(Employee);
        }

        /// <summary>
        /// Remove a employee from the data base with matching id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var Employee = await _employeeContext.EmployeeInfo.FindAsync(id);
            if(Employee == null) { return NotFound(id);}
            _employeeContext.EmployeeInfo.Remove(Employee); 
            await _employeeContext.SaveChangesAsync();
            return Ok("Employee " + Employee.eName + " has been deleted");
        }

        /// <summary>
        /// Return a list of employees that matchs the type of employee they are
        /// Uses a dto to restrict data recived (no salary or dependent count.
        /// </summary>
        /// <param name="type">eEmployementType</param>
        [HttpGet("{type}")]
        public async Task<IActionResult> FindByType(string type)
        {
            var Employees = await _employeeContext.EmployeeInfo.Where(e=>e.eEmploymentType == type).ToListAsync();
            var list = new List<TypeDTO>();
            foreach (var Employee in Employees)
            {
                list.Add(new TypeDTO()
                {
                    eId = Employee.eId,
                    eName = Employee.eName,
                    eEmail = Employee.eEmail,
                    eEmploymentType = Employee.eEmploymentType
                });
            }
            return Ok(list);
        }
        /// <summary>
        /// Return list of employees with a higher salary then input
        /// </summary>
        [HttpGet("{money}")]
        public async Task<IActionResult> FindHighPaid(int money)
        {
            var Employees = await _employeeContext.EmployeeInfo.Where(e => e.eSalary > money).ToListAsync();
            return Ok(Employees);
        }

        /// <summary>
        /// Return info about me (Ryan), from my table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DevInfo()
        {
            var student = await _employeeContext.students.FirstAsync();
            return Ok(student);
        }
    }
}
