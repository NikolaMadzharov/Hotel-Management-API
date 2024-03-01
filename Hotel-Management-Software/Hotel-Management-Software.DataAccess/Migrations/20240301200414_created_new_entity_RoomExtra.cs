using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DAL.Migrations
{
    /// <inheritdoc />
    public partial class created_new_entity_RoomExtra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Rooms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCleaned",
                table: "Rooms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RoomExtras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomExtras_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomExtras_RoomId",
                table: "RoomExtras",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomExtras");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsCleaned",
                table: "Rooms");
        }
    }
}
