using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeEleccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Primero borramos la FK actual
            migrationBuilder.DropForeignKey(
                name: "FK_EleccionListas_Eleccion_IdEleccion",
                table: "EleccionListas");

            // La volvemos a crear con Cascade
            migrationBuilder.AddForeignKey(
                name: "FK_EleccionListas_Eleccion_IdEleccion",
                table: "EleccionListas",
                column: "IdEleccion",
                principalTable: "Eleccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Volvemos al comportamiento anterior (Restrict o NoAction, según estaba en tu DB)
            migrationBuilder.DropForeignKey(
                name: "FK_EleccionListas_Eleccion_IdEleccion",
                table: "EleccionListas");

            migrationBuilder.AddForeignKey(
                name: "FK_EleccionListas_Eleccion_IdEleccion",
                table: "EleccionListas",
                column: "IdEleccion",
                principalTable: "Eleccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
