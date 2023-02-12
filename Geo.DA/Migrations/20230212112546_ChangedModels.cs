using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Expeditions_ExpeditionId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_ExpeditionId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ExpeditionId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "RouteID",
                table: "Expeditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_RouteID",
                table: "Expeditions",
                column: "RouteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expeditions_Routes_RouteID",
                table: "Expeditions",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expeditions_Routes_RouteID",
                table: "Expeditions");

            migrationBuilder.DropIndex(
                name: "IX_Expeditions_RouteID",
                table: "Expeditions");

            migrationBuilder.DropColumn(
                name: "RouteID",
                table: "Expeditions");

            migrationBuilder.AddColumn<int>(
                name: "ExpeditionId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ExpeditionId",
                table: "Routes",
                column: "ExpeditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Expeditions_ExpeditionId",
                table: "Routes",
                column: "ExpeditionId",
                principalTable: "Expeditions",
                principalColumn: "Id");
        }
    }
}
