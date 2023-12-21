using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Arancia.Migrations
{
    public partial class DesenvolvedoreseEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Empresas_EmpresaId",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_EmpresaId",
                table: "Projetos");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedoresId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projetos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                columns: new[] { "EmpresaId", "DesenvolvedoresId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos",
                column: "DesenvolvedoresId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Empresas_EmpresaId",
                table: "Projetos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Empresas_EmpresaId",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projetos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedoresId",
                table: "Projetos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Projetos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_EmpresaId",
                table: "Projetos",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos",
                column: "DesenvolvedoresId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Empresas_EmpresaId",
                table: "Projetos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }
    }
}
