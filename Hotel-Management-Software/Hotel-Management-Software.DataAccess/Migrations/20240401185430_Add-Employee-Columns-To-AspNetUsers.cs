using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeColumnsToAspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HieredDate",
                table: "AspNetUsers",
                type: "Timestamp",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminationDate",
                table: "AspNetUsers",
                type: "Timestamp",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "AspNetUsers",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HieredDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TerminationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");
        }
    }
}
