using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriBiciclete.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biciclete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibila = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biciclete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inchirieri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BicicletaId = table.Column<int>(type: "int", nullable: false),
                    DataInchiriere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataReturnare = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inchirieri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inchirieri_Biciclete_BicicletaId",
                        column: x => x.BicicletaId,
                        principalTable: "Biciclete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inchirieri_Clienti_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InchiriereId = table.Column<int>(type: "int", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPlata = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plati_Inchirieri_InchiriereId",
                        column: x => x.InchiriereId,
                        principalTable: "Inchirieri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inchirieri_BicicletaId",
                table: "Inchirieri",
                column: "BicicletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inchirieri_ClientId",
                table: "Inchirieri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Plati_InchiriereId",
                table: "Plati",
                column: "InchiriereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plati");

            migrationBuilder.DropTable(
                name: "Inchirieri");

            migrationBuilder.DropTable(
                name: "Biciclete");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
