using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lib_repositorios.Migrations
{
    /// <inheritdoc />
    public partial class ContraseñaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Usuarios_ID_Usuario",
                table: "Auditorias");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_ID_Usuario",
                table: "Auditorias");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_ID_Usuario",
                table: "Auditorias",
                column: "ID_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Usuarios_ID_Usuario",
                table: "Auditorias",
                column: "ID_Usuario",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
