using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class MealPriceAddToMealPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "MealPlanRates",
                newName: "MealRate");

            migrationBuilder.AddColumn<decimal>(
                name: "PlanPrice",
                table: "MealPlans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanPrice",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "MealRate",
                table: "MealPlanRates",
                newName: "Price");
        }
    }
}
