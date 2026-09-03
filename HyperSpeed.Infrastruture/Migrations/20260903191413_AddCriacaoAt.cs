using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HyperSpeed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCriacaoAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Produtos_ProdutoId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_ProdutoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "CategoriasId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriacaoAt",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Destaque",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriasId",
                table: "Produtos",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriasId",
                table: "Produtos",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriasId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriasId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoriasId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CriacaoAt",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Destaque",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProdutoId",
                table: "Categorias",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Produtos_ProdutoId",
                table: "Categorias",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
