using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lib_repositorios.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCalsePermisosyAuditoriasn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Permisos_ID_Usuario",
                table: "Permisos",
                column: "ID_Usuario");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_Usuarios_ID_Usuario",
                table: "Permisos",
                column: "ID_Usuario",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Usuarios_ID_Usuario",
                table: "Auditorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_Usuarios_ID_Usuario",
                table: "Permisos");

            migrationBuilder.DropIndex(
                name: "IX_Permisos_ID_Usuario",
                table: "Permisos");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_ID_Usuario",
                table: "Auditorias");
        }
    }
}
