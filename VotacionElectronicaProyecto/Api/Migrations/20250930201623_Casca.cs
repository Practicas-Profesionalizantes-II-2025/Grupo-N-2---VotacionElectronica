using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Casca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EleccionListas_Lista_IdLista",
                table: "EleccionListas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Lista",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 9, 30, 17, 16, 22, 4, DateTimeKind.Local).AddTicks(4461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 9, 30, 17, 5, 14, 839, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.AddForeignKey(
                name: "FK_EleccionListas_Lista_IdLista",
                table: "EleccionListas",
                column: "IdLista",
                principalTable: "Lista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EleccionListas_Lista_IdLista",
                table: "EleccionListas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Lista",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 9, 30, 17, 5, 14, 839, DateTimeKind.Local).AddTicks(223),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 9, 30, 17, 16, 22, 4, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.AddForeignKey(
                name: "FK_EleccionListas_Lista_IdLista",
                table: "EleccionListas",
                column: "IdLista",
                principalTable: "Lista",
                principalColumn: "Id");
        }
    }
}
