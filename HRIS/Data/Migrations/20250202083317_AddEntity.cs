using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VnzId",
                table: "VnzLists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UnitsGroupId",
                table: "UnitsGroups",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Units",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StaffScheduleId",
                table: "StaffSchedules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SpecialtyId",
                table: "Specialties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ScientificTitleId",
                table: "ScientificTitles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ScientificDegreeId",
                table: "ScientificDegrees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Positions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "JobChangeOrderId",
                table: "JobChangeOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Faculties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmploymentOrderId",
                table: "EmploymentOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DismissalOrderId",
                table: "DismissalOrders",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VnzLists",
                newName: "VnzId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UnitsGroups",
                newName: "UnitsGroupId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Units",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StaffSchedules",
                newName: "StaffScheduleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Specialties",
                newName: "SpecialtyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ScientificTitles",
                newName: "ScientificTitleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ScientificDegrees",
                newName: "ScientificDegreeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Positions",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JobChangeOrders",
                newName: "JobChangeOrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Faculties",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmploymentOrders",
                newName: "EmploymentOrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DismissalOrders",
                newName: "DismissalOrderId");
        }
    }
}
