using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PositionNameFull = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "ScientificDegrees",
                columns: table => new
                {
                    ScientificDegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScientificDegreeName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ScientificDegreeNameFull = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificDegrees", x => x.ScientificDegreeId);
                });

            migrationBuilder.CreateTable(
                name: "ScientificTitles",
                columns: table => new
                {
                    ScientificTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScientificTitleName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ScientificTitleNameFull = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificTitles", x => x.ScientificTitleId);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chiper = table.Column<int>(type: "int", nullable: true),
                    SpecialtyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "UnitsGroups",
                columns: table => new
                {
                    UnitsGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitsGroupName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsGroups", x => x.UnitsGroupId);
                });

            migrationBuilder.CreateTable(
                name: "VnzLists",
                columns: table => new
                {
                    VnzId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VnzName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VnzNameFull = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VnzAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VnzLists", x => x.VnzId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_UnitsGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UnitsGroups",
                        principalColumn: "UnitsGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FacultyNameFull = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VnzId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                    table.ForeignKey(
                        name: "FK_Faculties_VnzLists_VnzId",
                        column: x => x.VnzId,
                        principalTable: "VnzLists",
                        principalColumn: "VnzId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffSchedules",
                columns: table => new
                {
                    StaffScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPositions = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    NumberOfPositionsOccupied = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSchedules", x => x.StaffScheduleId);
                    table.ForeignKey(
                        name: "FK_StaffSchedules_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffSchedules_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_VnzId",
                table: "Faculties",
                column: "VnzId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSchedules_PositionId",
                table: "StaffSchedules",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSchedules_UnitId",
                table: "StaffSchedules",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_GroupId",
                table: "Units",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "ScientificDegrees");

            migrationBuilder.DropTable(
                name: "ScientificTitles");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "StaffSchedules");

            migrationBuilder.DropTable(
                name: "VnzLists");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "UnitsGroups");
        }
    }
}
