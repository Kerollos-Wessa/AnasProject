using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnasProject.Migrations
{
    /// <inheritdoc />
    public partial class addRouteHistories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RouteHistories_VehicleId",
                table: "RouteHistories");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHistories_VehicleId",
                table: "RouteHistories",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RouteHistories_VehicleId",
                table: "RouteHistories");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHistories_VehicleId",
                table: "RouteHistories",
                column: "VehicleId",
                unique: true);
        }
    }
}
