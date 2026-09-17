using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HyperSpeed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pedidos");
        }
    }
}
