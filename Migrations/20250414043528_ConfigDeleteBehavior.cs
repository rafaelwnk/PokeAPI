﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConfigDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Region",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonType_PokemonId",
                table: "PokemonType");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonType_TypeId",
                table: "PokemonType");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Region",
                table: "Pokemon",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonType_PokemonId",
                table: "PokemonType",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonType_TypeId",
                table: "PokemonType",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Region",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonType_PokemonId",
                table: "PokemonType");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonType_TypeId",
                table: "PokemonType");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Region",
                table: "Pokemon",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonType_PokemonId",
                table: "PokemonType",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonType_TypeId",
                table: "PokemonType",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
