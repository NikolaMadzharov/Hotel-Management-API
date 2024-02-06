using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class edited_hotel_entity_removed_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelPasswordSalt",
                table: "Hotels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelPasswordSalt",
                table: "Hotels",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
