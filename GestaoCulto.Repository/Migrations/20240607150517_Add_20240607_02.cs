using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoCulto.Repository.Migrations
{
    public partial class Add_20240607_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcoes_ministeriais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinisterioId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(60)", nullable: true),
                    IntrucoesFuncao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcoes_ministeriais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_funcoes_ministeriais_ministerios_MinisterioId",
                        column: x => x.MinisterioId,
                        principalTable: "ministerios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "musicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(60)", nullable: true),
                    Autor = table.Column<string>(type: "varchar(60)", nullable: true),
                    Letra = table.Column<string>(type: "text", nullable: true),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    CongregacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musicas_congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalTable: "congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcoes_ministeriais_MinisterioId",
                table: "funcoes_ministeriais",
                column: "MinisterioId");

            migrationBuilder.CreateIndex(
                name: "IX_musicas_CongregacaoId",
                table: "musicas",
                column: "CongregacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcoes_ministeriais");

            migrationBuilder.DropTable(
                name: "musicas");
        }
    }
}
