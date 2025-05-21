using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lib_repositorios.Migrations
{
    /// <inheritdoc />
    public partial class Migracion9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Bodegas_ID_Usuario",
                table: "Auditorias");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Usuarios_ID_Usuario",
                table: "Auditorias",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Bodegas_ID_Usuario",
                table: "Auditorias",
                column: "ID_Usuario",
                principalTable: "Bodegas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
