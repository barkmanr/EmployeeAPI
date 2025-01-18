using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCIncAPI_991690389.Migrations
{
    /// <inheritdoc />
    public partial class IM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                columns: table => new
                {
                    eId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    eName = table.Column<string>(type: "TEXT", nullable: true),
                    eEmail = table.Column<string>(type: "TEXT", nullable: true),
                    eEmploymentType = table.Column<string>(type: "TEXT", nullable: true),
                    eDependentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    eSalary = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfo", x => x.eId);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInfo");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
