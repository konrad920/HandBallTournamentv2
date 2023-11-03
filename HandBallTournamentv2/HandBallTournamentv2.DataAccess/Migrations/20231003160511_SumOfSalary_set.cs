using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandBallTournamentv2.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SumOfSalary_set : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SumOfSalary",
                table: "Clubs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SumOfSalary",
                table: "Clubs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
