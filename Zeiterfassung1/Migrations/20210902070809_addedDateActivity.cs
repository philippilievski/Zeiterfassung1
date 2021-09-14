using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zeiterfassung1.Migrations
{
    public partial class addedDateActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEmployee_Activities_TasksActivityID",
                table: "ActivityEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityEmployee",
                table: "ActivityEmployee");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEmployee_TasksActivityID",
                table: "ActivityEmployee");

            migrationBuilder.RenameColumn(
                name: "TasksActivityID",
                table: "ActivityEmployee",
                newName: "ActivitiesActivityID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateActivity",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityEmployee",
                table: "ActivityEmployee",
                columns: new[] { "ActivitiesActivityID", "EmployeesEmployeeID" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmployee_EmployeesEmployeeID",
                table: "ActivityEmployee",
                column: "EmployeesEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEmployee_Activities_ActivitiesActivityID",
                table: "ActivityEmployee",
                column: "ActivitiesActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEmployee_Activities_ActivitiesActivityID",
                table: "ActivityEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityEmployee",
                table: "ActivityEmployee");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEmployee_EmployeesEmployeeID",
                table: "ActivityEmployee");

            migrationBuilder.DropColumn(
                name: "DateActivity",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ActivitiesActivityID",
                table: "ActivityEmployee",
                newName: "TasksActivityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityEmployee",
                table: "ActivityEmployee",
                columns: new[] { "EmployeesEmployeeID", "TasksActivityID" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEmployee_TasksActivityID",
                table: "ActivityEmployee",
                column: "TasksActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEmployee_Activities_TasksActivityID",
                table: "ActivityEmployee",
                column: "TasksActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
