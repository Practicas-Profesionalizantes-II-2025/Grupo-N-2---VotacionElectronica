using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class MigracionFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEleccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionEleccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadListas = table.Column<int>(type: "int", nullable: false),
                    FechaFinEleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicioEleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ELECCION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLista = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DescripcionLista = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CantidadIntegrantes = table.Column<int>(type: "int", nullable: false),
                    EleccionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 11, 3, 17, 39, 53, 740, DateTimeKind.Local).AddTicks(7410)),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_LISTA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroIdentificacionPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraseniaPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumentoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_PERSONA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EleccionId = table.Column<int>(type: "int", nullable: false),
                    CantidadVotos = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_RESULTADO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultado_Eleccion_EleccionId",
                        column: x => x.EleccionId,
                        principalTable: "Eleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuestoCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLista = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Lista_IdLista",
                        column: x => x.IdLista,
                        principalTable: "Lista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleccionListas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEleccion = table.Column<int>(type: "int", nullable: false),
                    IdLista = table.Column<int>(type: "int", nullable: false),
                    DescripcionEleccionLista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleccionListas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EleccionListas_Eleccion_IdEleccion",
                        column: x => x.IdEleccion,
                        principalTable: "Eleccion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EleccionListas_Lista_IdLista",
                        column: x => x.IdLista,
                        principalTable: "Lista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonaElecciones",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    EleccionId = table.Column<int>(type: "int", nullable: false),
                    Autorizada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaElecciones", x => new { x.PersonaId, x.EleccionId });
                    table.ForeignKey(
                        name: "FK_PersonaElecciones_Eleccion_EleccionId",
                        column: x => x.EleccionId,
                        principalTable: "Eleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaElecciones_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVoto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraVoto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EleccionId = table.Column<int>(type: "int", nullable: false),
                    ListaId = table.Column<int>(type: "int", nullable: false),
                    ResultadoId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_VOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voto_Eleccion_EleccionId",
                        column: x => x.EleccionId,
                        principalTable: "Eleccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voto_Lista_ListaId",
                        column: x => x.ListaId,
                        principalTable: "Lista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Resultado_ResultadoId",
                        column: x => x.ResultadoId,
                        principalTable: "Resultado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_IdLista",
                table: "Candidatos",
                column: "IdLista");

            migrationBuilder.CreateIndex(
                name: "IX_EleccionListas_IdEleccion",
                table: "EleccionListas",
                column: "IdEleccion");

            migrationBuilder.CreateIndex(
                name: "IX_EleccionListas_IdLista",
                table: "EleccionListas",
                column: "IdLista");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaElecciones_EleccionId",
                table: "PersonaElecciones",
                column: "EleccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_EleccionId",
                table: "Resultado",
                column: "EleccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_EleccionId",
                table: "Voto",
                column: "EleccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_ListaId",
                table: "Voto",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_ResultadoId",
                table: "Voto",
                column: "ResultadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "EleccionListas");

            migrationBuilder.DropTable(
                name: "PersonaElecciones");

            migrationBuilder.DropTable(
                name: "Voto");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "Eleccion");
        }
    }
}
