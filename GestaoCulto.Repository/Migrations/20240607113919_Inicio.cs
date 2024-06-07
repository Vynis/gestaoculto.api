using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoCulto.Repository.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "congregacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: true),
                    Status = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congregacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parametros_sistema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: true),
                    Valor = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    CongregacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametros_sistema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parametros_sistema_congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalTable: "congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", nullable: true),
                    Senha = table.Column<string>(type: "varchar(20)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    CongregacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalTable: "congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parametros_sistema_CongregacaoId",
                table: "parametros_sistema",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_CongregacaoId",
                table: "usuarios",
                column: "CongregacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parametros_sistema");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "congregacao");
        }
    }
}
