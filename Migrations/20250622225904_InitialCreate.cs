﻿using System;
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
                name: "Clientes",
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
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "PaisDestinos",
                columns: table => new
                {
                    PaisDestinoID = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisDestinos", x => x.PaisDestinoID);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CidadeID = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    NumHabitantes = table.Column<int>(type: "INTEGER", nullable: false),
                    PaisDestinoId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidadeID);
                    table.ForeignKey(
                        name: "FK_Cidades_PaisDestinos_PaisDestinoId",
                        column: x => x.PaisDestinoId,
                        principalTable: "PaisDestinos",
                        principalColumn: "PaisDestinoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacotesTuristicos",
                columns: table => new
                {
                    PacoteTuriscoID = table.Column<string>(type: "TEXT", nullable: false),
                    NomeDoPacote = table.Column<string>(type: "TEXT", nullable: false),
                    DataDaViagem = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CapacidadeMax = table.Column<int>(type: "INTEGER", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaisDestinoId = table.Column<string>(type: "TEXT", nullable: false),
                    CidadeId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacotesTuristicos", x => x.PacoteTuriscoID);
                    table.ForeignKey(
                        name: "FK_PacotesTuristicos_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "CidadeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacotesTuristicos_PaisDestinos_PaisDestinoId",
                        column: x => x.PaisDestinoId,
                        principalTable: "PaisDestinos",
                        principalColumn: "PaisDestinoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<string>(type: "TEXT", nullable: false),
                    PacoteTuristicoId = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreateClienteClienteID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_CreateClienteClienteID",
                        column: x => x.CreateClienteClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK_Reservas_PacotesTuristicos_PacoteTuristicoId",
                        column: x => x.PacoteTuristicoId,
                        principalTable: "PacotesTuristicos",
                        principalColumn: "PacoteTuriscoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_PaisDestinoId",
                table: "Cidades",
                column: "PaisDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacotesTuristicos_CidadeId",
                table: "PacotesTuristicos",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_PacotesTuristicos_PaisDestinoId",
                table: "PacotesTuristicos",
                column: "PaisDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CreateClienteClienteID",
                table: "Reservas",
                column: "CreateClienteClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PacoteTuristicoId",
                table: "Reservas",
                column: "PacoteTuristicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PacotesTuristicos");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "PaisDestinos");
        }
    }
}
