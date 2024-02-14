using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingHotelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MidleName",
                table: "AspNetUsers",
                newName: "MiddleName");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "bytea", nullable: true),
                    OwnerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_OwnerId",
                table: "Hotels",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "AspNetUsers",
                newName: "MidleName");
        }
    }
}
