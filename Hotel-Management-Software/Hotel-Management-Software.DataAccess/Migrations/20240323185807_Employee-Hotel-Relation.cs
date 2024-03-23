using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeHotelRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeHotelId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeHotelId",
                table: "AspNetUsers",
                column: "EmployeeHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hotels_EmployeeHotelId",
                table: "AspNetUsers",
                column: "EmployeeHotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hotels_EmployeeHotelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeHotelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeHotelId",
                table: "AspNetUsers");
        }
    }
}
