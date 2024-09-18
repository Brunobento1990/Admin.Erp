using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmailEsqueceuSenhaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AcessosUsuarios",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AcessosUsuarios");
        }
    }
}
