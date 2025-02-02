using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonNameFull = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Residence = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MilitaryRegistrationStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsPensioner = table.Column<bool>(type: "bit", nullable: false),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PassportSeries = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PassportIssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    PassportIssuePlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonEducation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PersonQualification = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DiplomaNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfGraduation = table.Column<DateTime>(type: "date", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Discharge = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    ScientificTitleId = table.Column<int>(type: "int", nullable: true),
                    ScientificDegreeId = table.Column<int>(type: "int", nullable: true),
                    SpecialtyId = table.Column<int>(type: "int", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    DisabilityGroup = table.Column<int>(type: "int", nullable: true),
                    DisabledCertificate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId");
                    table.ForeignKey(
                        name: "FK_Persons_ScientificDegrees_ScientificDegreeId",
                        column: x => x.ScientificDegreeId,
                        principalTable: "ScientificDegrees",
                        principalColumn: "ScientificDegreeId");
                    table.ForeignKey(
                        name: "FK_Persons_ScientificTitles_ScientificTitleId",
                        column: x => x.ScientificTitleId,
                        principalTable: "ScientificTitles",
                        principalColumn: "ScientificTitleId");
                    table.ForeignKey(
                        name: "FK_Persons_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePersonId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    DateEmployment = table.Column<DateTime>(type: "date", nullable: true),
                    DateDismissal = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeWorkingRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Persons_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentOrders",
                columns: table => new
                {
                    EmploymentOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    WorkingRates = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Pluralist = table.Column<bool>(type: "bit", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentOrders", x => x.EmploymentOrderId);
                    table.ForeignKey(
                        name: "FK_EmploymentOrders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentOrders_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentOrders_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DismissalOrders",
                columns: table => new
                {
                    DismissalOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DismissalDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DismissalOrders", x => x.DismissalOrderId);
                    table.ForeignKey(
                        name: "FK_DismissalOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobChangeOrders",
                columns: table => new
                {
                    JobChangeOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NewPositionId = table.Column<int>(type: "int", nullable: false),
                    NewUnitId = table.Column<int>(type: "int", nullable: false),
                    JobChangeDate = table.Column<DateTime>(type: "date", nullable: false),
                    NewWorkingRates = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobChangeOrders", x => x.JobChangeOrderId);
                    table.ForeignKey(
                        name: "FK_JobChangeOrders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobChangeOrders_Positions_NewPositionId",
                        column: x => x.NewPositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobChangeOrders_Units_NewUnitId",
                        column: x => x.NewUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DismissalOrders_EmployeeId",
                table: "DismissalOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeePersonId",
                table: "Employees",
                column: "EmployeePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UnitId",
                table: "Employees",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentOrders_PersonId",
                table: "EmploymentOrders",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentOrders_PositionId",
                table: "EmploymentOrders",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentOrders_UnitId",
                table: "EmploymentOrders",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_JobChangeOrders_EmployeeId",
                table: "JobChangeOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobChangeOrders_NewPositionId",
                table: "JobChangeOrders",
                column: "NewPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobChangeOrders_NewUnitId",
                table: "JobChangeOrders",
                column: "NewUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FacultyId",
                table: "Persons",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ScientificDegreeId",
                table: "Persons",
                column: "ScientificDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ScientificTitleId",
                table: "Persons",
                column: "ScientificTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SpecialtyId",
                table: "Persons",
                column: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DismissalOrders");

            migrationBuilder.DropTable(
                name: "EmploymentOrders");

            migrationBuilder.DropTable(
                name: "JobChangeOrders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
