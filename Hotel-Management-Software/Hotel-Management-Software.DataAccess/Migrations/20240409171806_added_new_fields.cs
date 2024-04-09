using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_Software.DAL.Migrations
{
    /// <inheritdoc />
    public partial class added_new_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleCapacity",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerNight",
                table: "Rooms",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleCapacity",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "Rooms");
        }
    }
}
