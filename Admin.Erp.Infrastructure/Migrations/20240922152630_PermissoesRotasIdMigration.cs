using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PermissoesRotasIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuarioMenuRotas_PerfilUsuarioMenus_PerfilUsuarioMenu~",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilUsuarioMenus",
                table: "PerfilUsuarioMenus");

            migrationBuilder.DropIndex(
                name: "IX_PerfilUsuarioMenuRotas_PerfilUsuarioMenuMenuId_PerfilUsuari~",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.DropColumn(
                name: "PerfilUsuarioMenuMenuId",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.DropColumn(
                name: "PerfilUsuarioMenuPerfilUsuarioId",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PerfilUsuarioMenus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PerfilUsuarioMenuId",
                table: "PerfilUsuarioMenuRotas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilUsuarioMenus",
                table: "PerfilUsuarioMenus",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenuRotas_PerfilUsuarioMenuId",
                table: "PerfilUsuarioMenuRotas",
                column: "PerfilUsuarioMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuarioMenuRotas_PerfilUsuarioMenus_PerfilUsuarioMenu~",
                table: "PerfilUsuarioMenuRotas",
                column: "PerfilUsuarioMenuId",
                principalTable: "PerfilUsuarioMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuarioMenuRotas_PerfilUsuarioMenus_PerfilUsuarioMenu~",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilUsuarioMenus",
                table: "PerfilUsuarioMenus");

            migrationBuilder.DropIndex(
                name: "IX_PerfilUsuarioMenuRotas_PerfilUsuarioMenuId",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PerfilUsuarioMenus");

            migrationBuilder.DropColumn(
                name: "PerfilUsuarioMenuId",
                table: "PerfilUsuarioMenuRotas");

            migrationBuilder.AddColumn<Guid>(
                name: "PerfilUsuarioMenuMenuId",
                table: "PerfilUsuarioMenuRotas",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PerfilUsuarioMenuPerfilUsuarioId",
                table: "PerfilUsuarioMenuRotas",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilUsuarioMenus",
                table: "PerfilUsuarioMenus",
                columns: new[] { "MenuId", "PerfilUsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioMenuRotas_PerfilUsuarioMenuMenuId_PerfilUsuari~",
                table: "PerfilUsuarioMenuRotas",
                columns: new[] { "PerfilUsuarioMenuMenuId", "PerfilUsuarioMenuPerfilUsuarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuarioMenuRotas_PerfilUsuarioMenus_PerfilUsuarioMenu~",
                table: "PerfilUsuarioMenuRotas",
                columns: new[] { "PerfilUsuarioMenuMenuId", "PerfilUsuarioMenuPerfilUsuarioId" },
                principalTable: "PerfilUsuarioMenus",
                principalColumns: new[] { "MenuId", "PerfilUsuarioId" });
        }
    }
}
