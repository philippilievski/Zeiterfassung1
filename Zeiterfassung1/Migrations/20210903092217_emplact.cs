using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zeiterfassung1.Migrations
{
    public partial class emplact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityEmployee");

            migrationBuilder.DropColumn(
                name: "DateActivity",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "EmployeeActivity",
                columns: table => new
                {
                    EmployeeActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    ActivityID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeActivity", x => x.EmployeeActivityID);
                    table.ForeignKey(
                        name: "FK_EmployeeActivity_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeActivity_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeActivity_ActivityID",
                table: "EmployeeActivity",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeActivity_EmployeeID",
                table: "EmployeeActivity",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeActivity");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateActivity",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityEmployee",
                columns: table => new
                {
                    ActivitiesActivityID = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEmployee", x => new { x.ActivitiesActivityID, x.EmployeesEmployeeID });
                    table.ForeignKey(
                        name: "FK_ActivityEmployee_Activities_ActivitiesActivityID",
                        column: x => x.ActivitiesActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEmployee_Employees_EmployeesEmployeeID",
                        column: x => x.EmployeesEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmployee_EmployeesEmployeeID",
                table: "ActivityEmployee",
                column: "EmployeesEmployeeID");
        }
    }
}
