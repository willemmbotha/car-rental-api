using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Rental.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceAndPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                schema: "CR",
                table: "Vehicle",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalPrice",
                schema: "CR",
                table: "Vehicle",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                schema: "CR",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "RentalPrice",
                schema: "CR",
                table: "Vehicle");
        }
    }
}
