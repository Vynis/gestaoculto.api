using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoCulto.Repository.Migrations
{
    public partial class Add_20240607_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ministerios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(60)", nullable: true),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    CongregacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ministerios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ministerios_congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalTable: "congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pessoas_ministerios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinisterioId = table.Column<int>(nullable: false),
                    PessoasId = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoas_ministerios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pessoas_ministerios_ministerios_MinisterioId",
                        column: x => x.MinisterioId,
                        principalTable: "ministerios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pessoas_ministerios_pessoas_PessoasId",
                        column: x => x.PessoasId,
                        principalTable: "pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ministerios_CongregacaoId",
                table: "ministerios",
                column: "CongregacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoas_ministerios_MinisterioId",
                table: "pessoas_ministerios",
                column: "MinisterioId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoas_ministerios_PessoasId",
                table: "pessoas_ministerios",
                column: "PessoasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoas_ministerios");

            migrationBuilder.DropTable(
                name: "ministerios");
        }
    }
}
