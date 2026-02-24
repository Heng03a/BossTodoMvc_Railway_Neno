using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BossTodoMvc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialNeonAppSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.RenameTable(
                name: "todo_items",
                newName: "todo_items",
                newSchema: "app");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "todo_items",
                schema: "app",
                newName: "todo_items");
        }
    }
}
