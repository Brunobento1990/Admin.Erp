using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermissoesMenuListMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilUsuarioMenus_PerfilUsuarioId",
                table: "PerfilUsuarioMenus");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenus_PerfilUsuarioId",
                table: "PerfilUsuarioMenus",
                column: "PerfilUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PerfilUsuarioMenus_PerfilUsuarioId",
                table: "PerfilUsuarioMenus");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenus_PerfilUsuarioId",
                table: "PerfilUsuarioMenus",
                column: "PerfilUsuarioId",
                unique: true);
        }
    }
}
