using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Arancia.Migrations
{
    public partial class ProjetoseDesenvolvedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedoresId",
                table: "Projetos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_DesenvolvedoresId",
                table: "Projetos",
                column: "DesenvolvedoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos",
                column: "DesenvolvedoresId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_DesenvolvedoresId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "DesenvolvedoresId",
                table: "Projetos");
        }
    }
}
