using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnasProject.Migrations
{
    /// <inheritdoc />
    public partial class @double : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleGeofences_Geofences_GeofenceId",
                table: "CircleGeofences");

            migrationBuilder.DropForeignKey(
                name: "FK_PolygonGeofences_Geofences_GeofenceId",
                table: "PolygonGeofences");

            migrationBuilder.DropForeignKey(
                name: "FK_RectangleGeofences_Geofences_GeofenceId",
                table: "RectangleGeofences");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "RouteHistories",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "RouteHistories",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "West",
                table: "RectangleGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "South",
                table: "RectangleGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "North",
                table: "RectangleGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GeofenceId",
                table: "RectangleGeofences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "East",
                table: "RectangleGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "PolygonGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "PolygonGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GeofenceId",
                table: "PolygonGeofences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "StrockWeight",
                table: "Geofences",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "StrockOpacity",
                table: "Geofences",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FillOpacity",
                table: "Geofences",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Radius",
                table: "CircleGeofences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "CircleGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "CircleGeofences",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GeofenceId",
                table: "CircleGeofences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CircleGeofences_Geofences_GeofenceId",
                table: "CircleGeofences",
                column: "GeofenceId",
                principalTable: "Geofences",
                principalColumn: "GeofenceId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PolygonGeofences_Geofences_GeofenceId",
                table: "PolygonGeofences",
                column: "GeofenceId",
                principalTable: "Geofences",
                principalColumn: "GeofenceId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RectangleGeofences_Geofences_GeofenceId",
                table: "RectangleGeofences",
                column: "GeofenceId",
                principalTable: "Geofences",
                principalColumn: "GeofenceId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleGeofences_Geofences_GeofenceId",
                table: "CircleGeofences");

            migrationBuilder.DropForeignKey(
                name: "FK_PolygonGeofences_Geofences_GeofenceId",
                table: "PolygonGeofences");

            migrationBuilder.DropForeignKey(
                name: "FK_RectangleGeofences_Geofences_GeofenceId",
                table: "RectangleGeofences");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "RouteHistories",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "RouteHistories",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "West",
                table: "RectangleGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "South",
                table: "RectangleGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "North",
                table: "RectangleGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GeofenceId",
                table: "RectangleGeofences",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "East",
                table: "RectangleGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "PolygonGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "PolygonGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GeofenceId",
                table: "PolygonGeofences",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "StrockWeight",
                table: "Geofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "StrockOpacity",
                table: "Geofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "FillOpacity",
                table: "Geofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Radius",
                table: "CircleGeofences",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "Longitude",
                table: "CircleGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "CircleGeofences",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "GeofenceId",
                table: "CircleGeofences",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CircleGeofences_Geofences_GeofenceId",
                table: "CircleGeofences",
                column: "GeofenceId",
                principalTable: "Geofences",
                principalColumn: "GeofenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolygonGeofences_Geofences_GeofenceId",
                table: "PolygonGeofences",
                column: "GeofenceId",
                principalTable: "Geofences",
                principalColumn: "GeofenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_RectangleGeofences_Geofences_GeofenceId",
                table: "RectangleGeofences",
                column: "GeofenceId",
                principalTable: "Geofences",
                principalColumn: "GeofenceId");
        }
    }
}
