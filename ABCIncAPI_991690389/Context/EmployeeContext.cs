using ABCIncAPI_991690389.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCIncAPI_991690389.Context
{
    /// <summary>
    /// DB context:
    /// Employee table + table for my student info
    /// </summary>
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<EmployeeDM> EmployeeInfo { get; set; }
        public DbSet<StudentDM> students { get; set; }

    }
}
