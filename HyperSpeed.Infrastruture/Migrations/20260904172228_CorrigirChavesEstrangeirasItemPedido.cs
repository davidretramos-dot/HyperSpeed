using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HyperSpeed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirChavesEstrangeirasItemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "ItensPedido");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "ItensPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPedido",
                table: "ItensPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "ItensPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
