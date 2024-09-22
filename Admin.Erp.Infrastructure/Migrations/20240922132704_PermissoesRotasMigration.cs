using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermissoesRotasMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerfilUsuarioMenuRotas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuRotaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerfilUsuarioMenuMenuId = table.Column<Guid>(type: "uuid", nullable: true),
                    PerfilUsuarioMenuPerfilUsuarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarioMenuRotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioMenuRotas_MenuRotas_MenuRotaId",
                        column: x => x.MenuRotaId,
                        principalTable: "MenuRotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioMenuRotas_PerfilUsuarioMenus_PerfilUsuarioMenu~",
                        columns: x => new { x.PerfilUsuarioMenuMenuId, x.PerfilUsuarioMenuPerfilUsuarioId },
                        principalTable: "PerfilUsuarioMenus",
                        principalColumns: new[] { "MenuId", "PerfilUsuarioId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenuRotas_MenuRotaId",
                table: "PerfilUsuarioMenuRotas",
                column: "MenuRotaId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenuRotas_PerfilUsuarioMenuMenuId_PerfilUsuari~",
                table: "PerfilUsuarioMenuRotas",
                columns: new[] { "PerfilUsuarioMenuMenuId", "PerfilUsuarioMenuPerfilUsuarioId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUsuarioMenuRotas");
        }
    }
}
