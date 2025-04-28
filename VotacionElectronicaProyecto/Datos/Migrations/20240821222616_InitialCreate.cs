using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eleccion",
                columns: table => new
                {
                    IdEleccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEleccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionEleccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicioEleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinEleccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoEleccion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ELECCION", x => x.IdEleccion);
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    IdLista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionLista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadIntegrantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_LISTA", x => x.IdLista);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadVotos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_RESULTADO", x => x.IdResultado);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ROL", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuestoCandidato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_CANDIDATO", x => x.IdCandidato);
                    table.ForeignKey(
                        name: "FK_Candidatos_Lista_IdLista",
                        column: x => x.IdLista,
                        principalTable: "Lista",
                        principalColumn: "IdLista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleccionLista",
                columns: table => new
                {
                    IdEleccionLista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEleccion = table.Column<int>(type: "int", nullable: false),
                    IdLista = table.Column<int>(type: "int", nullable: false),
                    DescripcionEleccionLista = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ELECCIONLISTA", x => x.IdEleccionLista);
                    table.ForeignKey(
                        name: "FK_EleccionLista_Eleccion_IdEleccion",
                        column: x => x.IdEleccion,
                        principalTable: "Eleccion",
                        principalColumn: "IdEleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleccionLista_Lista_IdLista",
                        column: x => x.IdLista,
                        principalTable: "Lista",
                        principalColumn: "IdLista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    IdVoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVoto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraVoto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEleccion = table.Column<int>(type: "int", nullable: false),
                    IdLista = table.Column<int>(type: "int", nullable: false),
                    IdResultado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_VOTO", x => x.IdVoto);
                    table.ForeignKey(
                        name: "FK_Voto_Eleccion_IdEleccion",
                        column: x => x.IdEleccion,
                        principalTable: "Eleccion",
                        principalColumn: "IdEleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Lista_IdLista",
                        column: x => x.IdLista,
                        principalTable: "Lista",
                        principalColumn: "IdLista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Resultado_IdResultado",
                        column: x => x.IdResultado,
                        principalTable: "Resultado",
                        principalColumn: "IdResultado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContraseñaPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_PERSONA", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Persona_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votante",
                columns: table => new
                {
                    IdVotante = table.Column<int>(type: "int", nullable: false),
                    EstadoVotacion = table.Column<bool>(type: "bit", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_VOTANTE", x => x.IdVotante);
                    table.ForeignKey(
                        name: "FK_Votante_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona");
                    table.ForeignKey(
                        name: "FK_Votante_Voto_IdVotante",
                        column: x => x.IdVotante,
                        principalTable: "Voto",
                        principalColumn: "IdVoto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_IdLista",
                table: "Candidatos",
                column: "IdLista");

            migrationBuilder.CreateIndex(
                name: "IX_EleccionLista_IdEleccion",
                table: "EleccionLista",
                column: "IdEleccion");

            migrationBuilder.CreateIndex(
                name: "IX_EleccionLista_IdLista",
                table: "EleccionLista",
                column: "IdLista");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdRol",
                table: "Persona",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Votante_IdPersona",
                table: "Votante",
                column: "IdPersona",
                unique: true,
                filter: "[IdPersona] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_IdEleccion",
                table: "Voto",
                column: "IdEleccion");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_IdLista",
                table: "Voto",
                column: "IdLista");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_IdResultado",
                table: "Voto",
                column: "IdResultado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "EleccionLista");

            migrationBuilder.DropTable(
                name: "Votante");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Voto");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Eleccion");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "Resultado");
        }
    }
}
