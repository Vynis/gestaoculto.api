using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoCulto.Repository.Migrations
{
    public partial class AddDtExclusaoPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "pessoas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "pessoas");
        }
    }
}
