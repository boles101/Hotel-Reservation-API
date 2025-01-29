using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class MealPlanRatesRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanRates");

            migrationBuilder.RenameColumn(
                name: "RatePerRoom",
                table: "RoomRates",
                newName: "RateMultiplier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RateMultiplier",
                table: "RoomRates",
                newName: "RatePerRoom");

            migrationBuilder.CreateTable(
                name: "MealPlanRates",
                columns: table => new
                {
                    MealRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealPlanID = table.Column<int>(type: "int", nullable: false),
                    MealRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanRates", x => x.MealRateID);
                    table.ForeignKey(
                        name: "FK_MealPlanRates_MealPlans_MealPlanID",
                        column: x => x.MealPlanID,
                        principalTable: "MealPlans",
                        principalColumn: "MealPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanRates_MealPlanID",
                table: "MealPlanRates",
                column: "MealPlanID");
        }
    }
}
