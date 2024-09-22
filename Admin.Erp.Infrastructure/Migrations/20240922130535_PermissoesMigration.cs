using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermissoesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PerfilUsuarioId",
                table: "Usuarios",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MenuRotas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rota = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuRotas_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    EmpresaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuarioMenus",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerfilUsuarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarioMenus", x => new { x.MenuId, x.PerfilUsuarioId });
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioMenus_PerfilUsuarios_PerfilUsuarioId",
                        column: x => x.PerfilUsuarioId,
                        principalTable: "PerfilUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilUsuarioId",
                table: "Usuarios",
                column: "PerfilUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRotas_MenuId",
                table: "MenuRotas",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenus_MenuId",
                table: "PerfilUsuarioMenus",
                column: "MenuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenus_PerfilUsuarioId",
                table: "PerfilUsuarioMenus",
                column: "PerfilUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_EmpresaId",
                table: "PerfilUsuarios",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_PerfilUsuarios_PerfilUsuarioId",
                table: "Usuarios",
                column: "PerfilUsuarioId",
                principalTable: "PerfilUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_PerfilUsuarios_PerfilUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "MenuRotas");

            migrationBuilder.DropTable(
                name: "PerfilUsuarioMenus");

            migrationBuilder.DropTable(
                name: "PerfilUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PerfilUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PerfilUsuarioId",
                table: "Usuarios");
        }
    }
}
