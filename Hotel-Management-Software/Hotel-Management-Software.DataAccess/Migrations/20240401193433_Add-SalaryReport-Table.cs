using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "Timestamp", nullable: false),
                    EmployeeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryReports_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryReports_EmployeeId",
                table: "SalaryReports",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryReports");
        }
    }
}
