using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnasProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Geofences",
                columns: table => new
                {
                    GeofenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeofenceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<long>(type: "bigint", nullable: true),
                    StrockColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrockOpacity = table.Column<float>(type: "real", nullable: true),
                    StrockWeight = table.Column<float>(type: "real", nullable: true),
                    FillColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FillOpacity = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geofences", x => x.GeofenceId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNumber = table.Column<long>(type: "bigint", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "CircleGeofences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeofenceId = table.Column<long>(type: "bigint", nullable: true),
                    Radius = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleGeofences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleGeofences_Geofences_GeofenceId",
                        column: x => x.GeofenceId,
                        principalTable: "Geofences",
                        principalColumn: "GeofenceId");
                });

            migrationBuilder.CreateTable(
                name: "PolygonGeofences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeofenceId = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonGeofences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolygonGeofences_Geofences_GeofenceId",
                        column: x => x.GeofenceId,
                        principalTable: "Geofences",
                        principalColumn: "GeofenceId");
                });

            migrationBuilder.CreateTable(
                name: "RectangleGeofences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeofenceId = table.Column<long>(type: "bigint", nullable: true),
                    North = table.Column<float>(type: "real", nullable: true),
                    East = table.Column<float>(type: "real", nullable: true),
                    West = table.Column<float>(type: "real", nullable: true),
                    South = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RectangleGeofences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RectangleGeofences_Geofences_GeofenceId",
                        column: x => x.GeofenceId,
                        principalTable: "Geofences",
                        principalColumn: "GeofenceId");
                });

            migrationBuilder.CreateTable(
                name: "RouteHistories",
                columns: table => new
                {
                    RouteHistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleDirection = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    VehicleSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Epoch = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteHistories", x => x.RouteHistoryId);
                    table.ForeignKey(
                        name: "FK_RouteHistories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: true),
                    DriverId = table.Column<long>(type: "bigint", nullable: true),
                    VehicleMake = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesInformations_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_VehiclesInformations_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircleGeofences_GeofenceId",
                table: "CircleGeofences",
                column: "GeofenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonGeofences_GeofenceId",
                table: "PolygonGeofences",
                column: "GeofenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RectangleGeofences_GeofenceId",
                table: "RectangleGeofences",
                column: "GeofenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteHistories_VehicleId",
                table: "RouteHistories",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesInformations_DriverId",
                table: "VehiclesInformations",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesInformations_VehicleId",
                table: "VehiclesInformations",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircleGeofences");

            migrationBuilder.DropTable(
                name: "PolygonGeofences");

            migrationBuilder.DropTable(
                name: "RectangleGeofences");

            migrationBuilder.DropTable(
                name: "RouteHistories");

            migrationBuilder.DropTable(
                name: "VehiclesInformations");

            migrationBuilder.DropTable(
                name: "Geofences");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
