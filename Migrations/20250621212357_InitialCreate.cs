using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "PaisesDestino",
                columns: table => new
                {
                    PaisDestinoID = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisesDestino", x => x.PaisDestinoID);
                });

            migrationBuilder.CreateTable(
                name: "PacotesTuriscos",
                columns: table => new
                {
                    PacoteTuriscoID = table.Column<string>(type: "TEXT", nullable: false),
                    NomeDoPacote = table.Column<string>(type: "TEXT", nullable: false),
                    DataDaViagem = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CapacidadeMax = table.Column<int>(type: "INTEGER", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaisDestinoID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesTuriscos", x => x.PacoteTuriscoID);
                    table.ForeignKey(
                        name: "FK_PacotesTuriscos_PaisesDestino_PaisDestinoID",
                        column: x => x.PaisDestinoID,
                        principalTable: "PaisesDestino",
                        principalColumn: "PaisDestinoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CidadeID = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    NumHabitantes = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatePacotesTuriscoPacoteTuriscoID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidadeID);
                    table.ForeignKey(
                        name: "FK_Cidades_PacotesTuriscos_CreatePacotesTuriscoPacoteTuriscoID",
                        column: x => x.CreatePacotesTuriscoPacoteTuriscoID,
                        principalTable: "PacotesTuriscos",
                        principalColumn: "PacoteTuriscoID");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteID = table.Column<string>(type: "TEXT", nullable: false),
                    PacoteTuriscoID = table.Column<string>(type: "TEXT", nullable: false),
                    PacotesTuriscoPacoteTuriscoID = table.Column<string>(type: "TEXT", nullable: true),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_PacotesTuriscos_PacotesTuriscoPacoteTuriscoID",
                        column: x => x.PacotesTuriscoPacoteTuriscoID,
                        principalTable: "PacotesTuriscos",
                        principalColumn: "PacoteTuriscoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CreatePacotesTuriscoPacoteTuriscoID",
                table: "Cidades",
                column: "CreatePacotesTuriscoPacoteTuriscoID");

            migrationBuilder.CreateIndex(
                name: "IX_PacotesTuriscos_PaisDestinoID",
                table: "PacotesTuriscos",
                column: "PaisDestinoID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteID",
                table: "Reservas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PacotesTuriscoPacoteTuriscoID",
                table: "Reservas",
                column: "PacotesTuriscoPacoteTuriscoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "PacotesTuriscos");

            migrationBuilder.DropTable(
                name: "PaisesDestino");
        }
    }
}
