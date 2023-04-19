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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 2);            
        }
    }
}
