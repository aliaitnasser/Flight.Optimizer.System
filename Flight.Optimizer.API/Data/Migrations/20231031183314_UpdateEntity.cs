using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight.Optimizer.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdult",
                table: "Passengers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdult",
                table: "Passengers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
