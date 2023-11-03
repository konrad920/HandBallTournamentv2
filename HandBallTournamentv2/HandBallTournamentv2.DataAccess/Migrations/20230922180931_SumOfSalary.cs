using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandBallTournamentv2.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SumOfSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sale",
                table: "Players");

            migrationBuilder.AddColumn<float>(
                name: "SumOfSalary",
                table: "Clubs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SumOfSalary",
                table: "Clubs");

            migrationBuilder.AddColumn<float>(
                name: "Sale",
                table: "Players",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
