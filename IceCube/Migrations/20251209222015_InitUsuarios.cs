using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceCube.Migrations
{
    public partial class InitUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatIdioma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strValor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatIdioma", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuPerfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strNombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    strGenero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    dtFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    strDescripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    strFotoPerfil = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    strCiudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    strPais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    strPreferenciaGenero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    idCatIdioma = table.Column<int>(type: "int", nullable: false),
                    CatIdiomaid = table.Column<int>(type: "int", nullable: true),
                    strOcupacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    strEscuelaEmpresa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    strObjetivo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    strSituaciones = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    strIntereses = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuPerfil", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsuPerfil_CatIdioma_CatIdiomaid",
                        column: x => x.CatIdiomaid,
                        principalTable: "CatIdioma",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuPerfil_CatIdiomaid",
                table: "UsuPerfil",
                column: "CatIdiomaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "UsuPerfil");

            migrationBuilder.DropTable(
                name: "CatIdioma");
        }
    }
}
