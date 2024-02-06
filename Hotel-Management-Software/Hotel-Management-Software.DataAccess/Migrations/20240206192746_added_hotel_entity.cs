using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hotel_Management_Software.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class added_hotel_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HotelName = table.Column<string>(type: "text", nullable: false),
                    HotelLocation = table.Column<string>(type: "text", nullable: false),
                    HotelTelephoneNumber = table.Column<string>(type: "text", nullable: false),
                    HotelPicture = table.Column<byte[]>(type: "bytea", nullable: false),
                    HotelEmailAddress = table.Column<string>(type: "text", nullable: false),
                    LoginNumber = table.Column<int>(type: "integer", nullable: false),
                    HotelPasswordHash = table.Column<string>(type: "text", nullable: false),
                    HotelPasswordSalt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
