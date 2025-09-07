using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConcertContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_ConcertSeasons_ConcertSeasonId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersInGroup_Instruments_InstrumentId",
                table: "PerformersInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersInGroup_Performers_PerformerId",
                table: "PerformersInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersInGroup_PiecesInConcert_PieceInConcertId",
                table: "PerformersInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PiecesInConcert_Concerts_ConcertId",
                table: "PiecesInConcert");

            migrationBuilder.DropForeignKey(
                name: "FK_PiecesInConcert_Pieces_PieceId",
                table: "PiecesInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PiecesInConcert",
                table: "PiecesInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformersInGroup",
                table: "PerformersInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts");

            migrationBuilder.RenameTable(
                name: "PiecesInConcert",
                newName: "PieceInConcert");

            migrationBuilder.RenameTable(
                name: "PerformersInGroup",
                newName: "PerformerInGroup");

            migrationBuilder.RenameTable(
                name: "Concerts",
                newName: "Concert");

            migrationBuilder.RenameIndex(
                name: "IX_PiecesInConcert_PieceId",
                table: "PieceInConcert",
                newName: "IX_PieceInConcert_PieceId");

            migrationBuilder.RenameIndex(
                name: "IX_PiecesInConcert_ConcertId",
                table: "PieceInConcert",
                newName: "IX_PieceInConcert_ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformersInGroup_PieceInConcertId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_PieceInConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformersInGroup_PerformerId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_PerformerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformersInGroup_InstrumentId",
                table: "PerformerInGroup",
                newName: "IX_PerformerInGroup_InstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_ConcertSeasonId",
                table: "Concert",
                newName: "IX_Concert_ConcertSeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieceInConcert",
                table: "PieceInConcert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformerInGroup",
                table: "PerformerInGroup",
                column: "Id");

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
                name: "FK_PerformerInGroup_Instruments_InstrumentId",
                table: "PerformerInGroup",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_Performers_PerformerId",
                table: "PerformerInGroup",
                column: "PerformerId",
                principalTable: "Performers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                table: "PerformerInGroup",
                column: "PieceInConcertId",
                principalTable: "PieceInConcert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceInConcert_Concert_ConcertId",
                table: "PieceInConcert",
                column: "ConcertId",
                principalTable: "Concert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PieceInConcert_Pieces_PieceId",
                table: "PieceInConcert",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_ConcertSeasons_ConcertSeasonId",
                table: "Concert");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_Instruments_InstrumentId",
                table: "PerformerInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_Performers_PerformerId",
                table: "PerformerInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformerInGroup_PieceInConcert_PieceInConcertId",
                table: "PerformerInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceInConcert_Concert_ConcertId",
                table: "PieceInConcert");

            migrationBuilder.DropForeignKey(
                name: "FK_PieceInConcert_Pieces_PieceId",
                table: "PieceInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieceInConcert",
                table: "PieceInConcert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformerInGroup",
                table: "PerformerInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.RenameTable(
                name: "PieceInConcert",
                newName: "PiecesInConcert");

            migrationBuilder.RenameTable(
                name: "PerformerInGroup",
                newName: "PerformersInGroup");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "Concerts");

            migrationBuilder.RenameIndex(
                name: "IX_PieceInConcert_PieceId",
                table: "PiecesInConcert",
                newName: "IX_PiecesInConcert_PieceId");

            migrationBuilder.RenameIndex(
                name: "IX_PieceInConcert_ConcertId",
                table: "PiecesInConcert",
                newName: "IX_PiecesInConcert_ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_PieceInConcertId",
                table: "PerformersInGroup",
                newName: "IX_PerformersInGroup_PieceInConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_PerformerId",
                table: "PerformersInGroup",
                newName: "IX_PerformersInGroup_PerformerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformerInGroup_InstrumentId",
                table: "PerformersInGroup",
                newName: "IX_PerformersInGroup_InstrumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_ConcertSeasonId",
                table: "Concerts",
                newName: "IX_Concerts_ConcertSeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PiecesInConcert",
                table: "PiecesInConcert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformersInGroup",
                table: "PerformersInGroup",
                column: "Id");

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
                name: "FK_PerformersInGroup_Instruments_InstrumentId",
                table: "PerformersInGroup",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersInGroup_Performers_PerformerId",
                table: "PerformersInGroup",
                column: "PerformerId",
                principalTable: "Performers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersInGroup_PiecesInConcert_PieceInConcertId",
                table: "PerformersInGroup",
                column: "PieceInConcertId",
                principalTable: "PiecesInConcert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiecesInConcert_Concerts_ConcertId",
                table: "PiecesInConcert",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PiecesInConcert_Pieces_PieceId",
                table: "PiecesInConcert",
                column: "PieceId",
                principalTable: "Pieces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
