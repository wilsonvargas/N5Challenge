using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace N5Challenge.Domain.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPermiso",
                table: "Permisos",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 14, 22, 38, 53, 626, DateTimeKind.Local).AddTicks(3756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "TipoPermisos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "Lectura" });

            migrationBuilder.InsertData(
                table: "TipoPermisos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 2, "Escritura" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "ApellidoEmpleado", "NombreEmpleado", "TipoPermiso" },
                values: new object[] { 1, "Doe", "John", 1 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "ApellidoEmpleado", "NombreEmpleado", "TipoPermiso" },
                values: new object[] { 2, "Miles", "Mike", 1 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "ApellidoEmpleado", "NombreEmpleado", "TipoPermiso" },
                values: new object[] { 3, "Laurence", "William", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPermiso",
                table: "Permisos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 38, 53, 626, DateTimeKind.Local).AddTicks(3756));
        }
    }
}
