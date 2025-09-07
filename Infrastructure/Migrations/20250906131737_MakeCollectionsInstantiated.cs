using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeCollectionsInstantiated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_ConcertSeasons_ConcertSeasonId",
                table: "Concert");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceInConcert_Concert_ConcertId",
                table: "PieceInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "Concerts");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_ConcertSeasonId",
                table: "Concerts",
                newName: "IX_Concerts_ConcertSeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_ConcertSeasons_ConcertSeasonId",
                table: "Concerts",
                column: "ConcertSeasonId",
                principalTable: "ConcertSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceInConcert_Concerts_ConcertId",
                table: "PieceInConcert",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_ConcertSeasons_ConcertSeasonId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceInConcert_Concerts_ConcertId",
                table: "PieceInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts");

            migrationBuilder.RenameTable(
                name: "Concerts",
                newName: "Concert");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_ConcertSeasonId",
                table: "Concert",
                newName: "IX_Concert_ConcertSeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concert",
                table: "Concert",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_ConcertSeasons_ConcertSeasonId",
                table: "Concert",
                column: "ConcertSeasonId",
                principalTable: "ConcertSeasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceInConcert_Concert_ConcertId",
                table: "PieceInConcert",
                column: "ConcertId",
                principalTable: "Concert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
