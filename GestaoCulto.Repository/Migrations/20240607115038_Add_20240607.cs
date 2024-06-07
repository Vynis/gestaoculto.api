using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoCulto.Repository.Migrations
{
    public partial class Add_20240607 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", nullable: true),
                    FoneCelular = table.Column<string>(type: "varchar(20)", nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    CongregacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pessoas_congregacao_CongregacaoId",
                        column: x => x.CongregacaoId,
                        principalTable: "congregacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoas_CongregacaoId",
                table: "pessoas",
                column: "CongregacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoas");
        }
    }
}
