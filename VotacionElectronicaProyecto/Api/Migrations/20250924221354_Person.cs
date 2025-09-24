using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrimerLogin",
                table: "Persona",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Lista",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 9, 24, 19, 13, 53, 160, DateTimeKind.Local).AddTicks(4281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 21, 9, 17, 34, 487, DateTimeKind.Local).AddTicks(4840));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimerLogin",
                table: "Persona");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Lista",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 21, 9, 17, 34, 487, DateTimeKind.Local).AddTicks(4840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 9, 24, 19, 13, 53, 160, DateTimeKind.Local).AddTicks(4281));
        }
    }
}
